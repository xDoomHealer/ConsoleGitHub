using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseUIController : MonoBehaviour {

    
    int buttonChosen = 0;
    float lastStep, timeBetweenSteps = 0.1f;

	// Use this for initialization
	void Start () {
        this.gameObject.transform.GetChild(buttonChosen).GetComponent<Image>().color = Color.red;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                this.gameObject.transform.GetChild(buttonChosen).GetComponent<Image>().color = Color.white;
                lastStep = Time.time;
                buttonChosen--;
                if (buttonChosen < 0)
                {
                    buttonChosen = 2;
                }
                this.gameObject.transform.GetChild(buttonChosen).GetComponent<Image>().color = Color.red;
            }
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                this.gameObject.transform.GetChild(buttonChosen).GetComponent<Image>().color = Color.white;
                lastStep = Time.time;
                buttonChosen++;
                if (buttonChosen > 2)
                    buttonChosen = 0;
                this.gameObject.transform.GetChild(buttonChosen).GetComponent<Image>().color = Color.red;
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                switch (buttonChosen)
                {
                    case 0:
                        Debug.Log("0");
                        AudioSettings.Running = true;
                    //    Time.timeScale = 1.0f;
                        this.gameObject.SetActive(false);

                        break;
                    case 1:
                        Debug.Log("1");
					//	Time.timeScale = 1.0f;
						AudioSettings.Running = true;
                        Application.LoadLevel("Title");
                        break;
                    case 2:
                        Debug.Log("2");
                        Application.Quit();
                        break;
                }
            }
        }



	}
}
