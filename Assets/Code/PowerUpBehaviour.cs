﻿using UnityEngine;
using System.Collections;

public class PowerUpBehaviour : MonoBehaviour
{
	enum PowerUpType {
		Health = 0,
		Ammo,
	}

	private PowerUpType type;
    // Use this for initialization
    void Start()
    {
		int randomNumber = Random.Range (0, 2);
		switch (randomNumber) {
		case 0: type = PowerUpType.Health;
			break;
		case 1: type = PowerUpType.Ammo;
			break;
		default:
			print ("PowerUp Out of index");
			break;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (AudioSettings.Running) {
			transform.Rotate (Vector3.up, 60f * Time.deltaTime);
		}
    }

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			PlayerBehaviour player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();

			if (type == PowerUpType.Health) {
				player.healthBar.value += 50;
			}
			else if (type == PowerUpType.Ammo) {
				PlayerBehaviour.Pistolammo += 5;
			}

			Destroy(this.gameObject);

		}
	}

}
