using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	[SerializeField] private string Level;
	

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player" && PlayerBehaviour.enemyList.Length == 0)
			Application.LoadLevel (Level);
	}
}
