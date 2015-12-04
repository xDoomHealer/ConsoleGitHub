using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

	public Slider healthBar;
	public Text AmmoText;
	public static int ammo;
	
	public static GameObject[] enemyList;
	
	// Use this for initialization
	void Start () {
		healthBar.maxValue = 250;
		healthBar.value = healthBar.maxValue;
		ammo = 10;
	}
	
	// Update is called once per frame
	void Update () {
		enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
		if (healthBar.value <= 0) {
			Application.LoadLevel ("Title");
		} else if (healthBar.value > healthBar.maxValue)
			healthBar.value = healthBar.maxValue;

		AmmoText.text = "Ammo:" + ammo;
	}
	
	 void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "bullet"){
			//decrease health
			Destroy(other.gameObject);
			healthBar.value  -=  20;
		}
		
	}
}
