using UnityEngine;
using System.Collections;

public class EnemyBehaviour : AIPath {
	
	// Use this for initialization
	public GameObject bulletPrefab;
	private GameObject _currentTarget;
	private float bulletTimer;
	
	void Start () {
		
		_currentTarget  = GameObject.Find("Player");
		if(_currentTarget!=null){

			target = _currentTarget.transform;
		}

		base.Start ();

	}
	
   	void Update () {
		bulletTimer+=Time.deltaTime;

        if (_currentTarget != null && _currentTarget.active){
			
			//set target for ai path script
			target = _currentTarget.transform;
			
			//shoot if dance is less than 10
			if (Vector3.Distance(transform.position, _currentTarget.transform.position) <= 5 ){
				
				if(bulletTimer > 2){
					
					shoot(_currentTarget.transform.position);
					bulletTimer = 0;
				}
			}
			
		}
	}
	
	void shoot(Vector3 pos){

		GameObject bulletObject = Object.Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		bulletObject.GetComponent<BulletBehaviour>().Initialize(transform.position, true, Color.red,_currentTarget.transform.position+new Vector3(0,1,0));
		
	}
}
