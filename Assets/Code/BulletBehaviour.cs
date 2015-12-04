using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	
	private Vector3 _startPos;
	private Color _color;
	private float startTime;
	private float journeyLength;
	private float speed = 1.0F;
	private Light muzzleFlash;
	private float muzzleFlashTime = 0.1f;
	private Vector3 _target;
	private bool _hit;
	private LineRenderer _lineRenderer;
	Vector3 randomPosition;
	float destroyTime;

	public void Initialize (Vector3 startPos, bool hit, Color color, Vector3 target)
	{
		_color = color;
		_startPos = startPos;
		_hit = hit;
		_target = target;
		
		muzzleFlash = this.gameObject.GetComponent<Light> ();
		muzzleFlash.enabled = true;
		
		startTime = Time.time;
		if (_hit) {
			journeyLength = Vector3.Distance (_startPos, _target);
			
		} else {
			//TODO change journey length
			randomPosition = new Vector3 (Random.Range (1, 30), Random.Range (1, 30), Random.Range (1, 30));
			journeyLength = Vector3.Distance (_startPos, _target + randomPosition);
		}

		muzzleFlash.enabled = false;
		_lineRenderer = GetComponent<LineRenderer>();
		_lineRenderer.SetWidth(.05f,.1f);
		_lineRenderer.SetPosition(0,startPos);
	}


	void Update () {
		
		destroyTime += Time.deltaTime;
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = (distCovered / journeyLength) * 100;
		
		if (_hit) {
			
			transform.position = Vector3.Lerp (_startPos, _target, fracJourney);
		} else {  
			transform.position = Vector3.Lerp (_startPos, _target + randomPosition, fracJourney);
		}
		_lineRenderer.SetPosition(1, transform.position);


		if(destroyTime>.25f){
			Destroy(gameObject);

		}
	}

	
}

