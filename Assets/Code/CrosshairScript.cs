using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {

	public Texture2D crosshairImage;
	private Vector2 hotspot;
	public AudioClip gunShot;
	private AudioSource sound;
	private Ray ray;
	private RaycastHit hit;

	public Vector3 hitTarget;

	void Start() {

		hotspot = new Vector2 (crosshairImage.width / 2, crosshairImage.height / 2);
		sound = GetComponent<AudioSource> ();
		sound.volume = AudioSettings.getSoundVol ();
		Cursor.SetCursor (crosshairImage, hotspot, CursorMode.ForceSoftware);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}

	void Update () {
	if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
		if (Input.GetMouseButtonDown (0) && PlayerBehaviour.ammo > 0) {
			sound.PlayOneShot(gunShot);
			PlayerBehaviour.ammo--;
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				hitTarget = hit.point;
				if (hit.transform.tag == "Enemy")
				{
					Destroy(hit.transform.gameObject);
				}
			}
		}
	}
}
