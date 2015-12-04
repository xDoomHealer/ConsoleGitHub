using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        //this.gameObject.GetComponent<Animation>().Play("");
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInChildren<Animation>()["DoorOpen"].speed = 1;
            this.gameObject.GetComponentInChildren<Animation>().Play("DoorOpen");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInChildren<Animation>()["DoorOpen"].speed = -1;
            this.gameObject.GetComponentInChildren<Animation>()["DoorOpen"].time = this.gameObject.GetComponentInChildren<Animation>()["DoorOpen"].length;
            this.gameObject.GetComponentInChildren<Animation>().Play("DoorOpen");
        }
    }
}
