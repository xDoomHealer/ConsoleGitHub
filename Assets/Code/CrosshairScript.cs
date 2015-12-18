using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {

	public Texture2D crosshairImage;
	private Vector2 hotspot;
	public AudioClip gunShot;
	private AudioSource sound;
	private Ray ray;
	private RaycastHit hit;
    public GameObject PauseUI;
    public GameObject Pistol;
    public GameObject ShotGun;

	//public Vector3 hitTarget;

	void Start() {
        AudioSettings.Running = true;
        PauseUI.SetActive(false);
		hotspot = new Vector2 (crosshairImage.width / 2, crosshairImage.height / 2);
		sound = GetComponent<AudioSource> ();
		sound.volume = AudioSettings.getSoundVol ();
        
		//Cursor.SetCursor (crosshairImage, hotspot, CursorMode.ForceSoftware);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update () {
        if (AudioSettings.Running)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AudioSettings.Running = false;
                PauseUI.SetActive(true);
                //Time.timeScale = 0.0f;
                //Application.Quit ();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlayerBehaviour.ShotGunOn = !PlayerBehaviour.ShotGunOn;
                if (PlayerBehaviour.ShotGunOn)
                {
                    ShotGun.SetActive(true);
                    Pistol.SetActive(false);
                }
                else
                {
                    ShotGun.SetActive(false);
                    Pistol.SetActive(true);
                }
            }
            if (!PlayerBehaviour.ShotGunOn)
            {
                Debug.Log("Pistol");
                PistolUpdate();
            }
            else
            {
                Debug.Log("ShotGun");
                ShotGunUpdate();
            }
        }
	}

    void PistolUpdate()
    {
        if (Input.GetMouseButtonDown(0) && PlayerBehaviour.Pistolammo > 0)
        {
            sound.PlayOneShot(gunShot, AudioSettings.getSoundVol() / 100);
            PlayerBehaviour.Pistolammo--;
           // ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(Camera.main.transform.position,ray.direction,Color.blue,4);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*50, Color.blue, 4);
          //  if (Physics.Raycast(ray, out hit))
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward *50,out hit,50))
            {
               // hitTarget = hit.point;
                if (hit.transform.tag == "Enemy")
                {
                    hit.collider.gameObject.SendMessage("Hit", 50, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    void ShotGunUpdate()
    {
        if(Input.GetMouseButtonDown(0) && PlayerBehaviour.ShotGunAmmo >0)
        {
            //sound.PlayOneShot(shotgun);
            PlayerBehaviour.ShotGunAmmo--;
            for(int i=0;i<6;i++)
            {
                int angle = Random.Range(-15, 15);
                Vector3 b = new Vector3(0, 0, 0);
                b.x = Random.Range(0, 2);
                b.y = Random.Range(0, 2);
                b.z = Random.Range(0, 2);
                Vector3 newVector = Quaternion.AngleAxis(angle, b) * Camera.main.transform.forward;
                RaycastHit hit;
                Debug.DrawRay(Camera.main.transform.position, newVector * 30, Color.yellow, 3);
                if (Physics.Raycast(Camera.main.transform.position, newVector * 30, out hit, 30))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        hit.collider.gameObject.SendMessage("Hit", 20, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}
