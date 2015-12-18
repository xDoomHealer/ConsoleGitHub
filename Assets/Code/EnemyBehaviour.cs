using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	// Use this for initialization
	public Animator anim;
	public GameObject bulletPrefab;
	private GameObject _currentTarget;
	private NavMeshAgent agent;
	private float bulletTimer;
    private float health;
	
	void Start () {
        health = 100;
		_currentTarget  = GameObject.Find("Player");
		agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();

	}
	
   	void Update () {
		if (AudioSettings.Running) {


			bulletTimer += Time.deltaTime;

			agent.SetDestination(_currentTarget.transform.position);

			if (_currentTarget != null && _currentTarget.active) {
			
				//shoot if dance is less than 10
				if (Vector3.Distance (transform.position, _currentTarget.transform.position) <= 3) {
				
					anim.SetBool("attack", true);
					anim.SetBool("running",false);
					anim.SetBool("idling", false);
					if (bulletTimer > 2) {
					
						shoot (_currentTarget.transform.position);
						bulletTimer = 0;
					}
				}

				else {
					anim.SetBool("attack", false);
					anim.SetBool("running",true);
					anim.SetBool("idling", false);
				}
			
			}
		} 
		else {
			agent.Stop();
			anim.SetBool("attack", false);
			anim.SetBool("running",false);
			anim.SetBool("idling", true);
		}
	}

    //Called when enemy get's hit
    void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
	
	void shoot(Vector3 pos){
		Vector3 direction = _currentTarget.transform.position - this.transform.position;
		Ray ray = new Ray (this.transform.position, direction);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "Player") {
				PlayerBehaviour p = _currentTarget.GetComponent<PlayerBehaviour>();
				p.healthBar.value -= 20;
			}
		}
		
	}
}
