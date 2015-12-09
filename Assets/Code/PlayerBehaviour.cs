using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

	public Slider healthBar;
	public Text AmmoText;
    public Text GunText;
	public static int Pistolammo;
    public static int ShotGunAmmo;


    public static bool ShotGunOn;
	
	public static GameObject[] enemyList;
	
	// Use this for initialization
	void Start () {
        ShotGunOn = false;
		healthBar.maxValue = 250;
		healthBar.value = healthBar.maxValue;
		Pistolammo = 10;
        ShotGunAmmo = 5;
	}
	
	// Update is called once per frame
	void Update () {
		enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
		if (healthBar.value <= 0) {
			Application.LoadLevel ("Title");
		} else if (healthBar.value > healthBar.maxValue)
			healthBar.value = healthBar.maxValue;

        if (ShotGunOn)
        {
            GunText.text = "Gun:ShotGun";
            AmmoText.text = "Ammo:" + ShotGunAmmo;
        }
        else
        {
            GunText.text = "Gun:Pistol";
            AmmoText.text = "Ammo:" + Pistolammo;
        }
	}
	
	 void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "bullet"){
			//decrease health
			Destroy(other.gameObject);
			healthBar.value  -=  20;
		}
		
	}
}
