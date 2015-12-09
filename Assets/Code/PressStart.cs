using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressStart : MonoBehaviour {

   [SerializeField] GameObject MenuButtons;
   [SerializeField] GameObject pressstarttext;
   [SerializeField] GameObject Settings;
   [SerializeField]
   GameObject Credits;
   [SerializeField]
   GameObject SettingSliders;
   //AudioSettings AudioControl;

   
   int MenuButtonChosen,MaxMenuButtons;
   int SettingButtonChosen, MaxSettingButtons;
   float lastStep, timeBetweenSteps = 0.1f;
   bool OnMusic, OnSound;
   States screen;
    enum States
    {
        Start,
        Menu,
        Settings,
        Credits
    }
	// Use this for initialization
	void Start () {
        //SoundSettings.gameObject.transform.Find("SoundSettings").GetComponent<SoundSettings>();
       // AudioControl = GameObject.Find("AudioSettings").GetComponent<AudioSettings>();
       
        screen = States.Start;
       // MenuButtons.SetActive(false);
      //  Settings.SetActive(false);
        MenuButtonChosen = 0;
        MaxMenuButtons = MenuButtons.transform.childCount-1;
        MaxSettingButtons = Settings.transform.childCount - 1;
        Debug.Log(SettingSliders.transform.GetChild(0).name);
	}
	
	// Update is called once per frame
	void Update () 
    {
        ScreenUpdate();
	}

    void StartUpdate()
    {
        if(pressstarttext.GetComponent<Text>().canvasRenderer.GetAlpha()>=0.9)
        {
           // Debug.Log("Fuck");
            pressstarttext.GetComponent<Text>().CrossFadeAlpha(0, 2, true);
        }
        else if (pressstarttext.GetComponent<Text>().canvasRenderer.GetAlpha() <= 0.1)
        {
            //Debug.Log("Bitch");
            pressstarttext.GetComponent<Text>().CrossFadeAlpha(1, 2, true);
        }
       if(Input.anyKey)
        {
            //Application.LoadLevel("Forest");
            //Debug.Log(MaxMenuButtons);
            //pressstarttext.SetActive(false);
            //MenuButtons.SetActive(true);
            MenuButtons.transform.GetChild(MenuButtonChosen).GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f); 
            lastStep = Time.time;
            screen = States.Menu;
        }
    }
    void MenuUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                MenuButtons.transform.GetChild(MenuButtonChosen).GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
                //ButtonChosen = Mathf.Clamp(ButtonChosen - 1, 0, MaxButtons);
                MenuButtonChosen--;
                if (MenuButtonChosen < 0)
                    MenuButtonChosen = MaxMenuButtons;
                MenuButtons.transform.GetChild(MenuButtonChosen).GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f);
               // Debug.Log(MenuButtonChosen);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                MenuButtons.transform.GetChild(MenuButtonChosen).GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
                //ButtonChosen = Mathf.Clamp(ButtonChosen + 1, 0, MaxButtons);
                MenuButtonChosen++;
                if (MenuButtonChosen > MaxMenuButtons)
                    MenuButtonChosen = 0;
                MenuButtons.transform.GetChild(MenuButtonChosen).GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f);
                //Debug.Log(MenuButtonChosen);
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                switch (MenuButtonChosen)
                {
                    case 0:
                        //Application.DontDestroyOnLoad(AudioControl.gameObject);
                        Application.LoadLevel("Forest");
                      //  Debug.Log("Enter 0 option");
                        break;
                    case 1:
                      //  Debug.Log("Enter 1st option");
                        break;
                    case 2:
                        //MenuButtons.SetActive(false);
                        // Settings.SetActive(true);
                        SettingButtonChosen = 0;
                        OnMusic = false;
                        OnSound = false;
                        screen = States.Settings;
                        Settings.transform.GetChild(SettingButtonChosen).GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f);
                      //  Debug.Log("Enter 2nd option");
                        break;
                    case 3:
                       // Debug.Log("Enter 3rd option");
                        break;
                    case 4:
                       // Debug.Log("Enter 4th option");                        
                        screen = States.Credits;
                        break;
                    case 5:
                        Application.Quit ();
                        break;
                }
            }
        }
    }

    void CreditsUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (Time.time - lastStep > timeBetweenSteps)
            {
                lastStep = Time.time;
                screen = States.Menu;
            }
        }
    }

    void SettingsUpdate()
    {
        SettingPicking();
        if (OnSound)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
               
                    //SettingSliders.transform.GetChild(0).GetComponent<Slider>().value--;
                    SettingSliders.transform.GetChild(0).GetComponent<Slider>().value = Mathf.Clamp(SettingSliders.transform.GetChild(0).GetComponent<Slider>().value - 1, 0, 100);
                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                //SettingSliders.transform.GetChild(0).GetComponent<Slider>().value++;
                SettingSliders.transform.GetChild(0).GetComponent<Slider>().value = Mathf.Clamp(SettingSliders.transform.GetChild(0).GetComponent<Slider>().value + 1, 0, 100);
            }
            
            if(Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    //AudioControl.setSoundVol(SettingSliders.transform.GetChild(0).GetComponent<Slider>().value);
                    AudioSettings.setSoundVol(SettingSliders.transform.GetChild(0).GetComponent<Slider>().value);
                    lastStep = Time.time;
                    OnSound = false;
                    screen = States.Settings;
                }
            }
        }
        if (OnMusic)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                   //SettingSliders.transform.GetChild(0).GetComponent<Slider>().value--;
                    SettingSliders.transform.GetChild(1).GetComponent<Slider>().value = Mathf.Clamp(SettingSliders.transform.GetChild(1).GetComponent<Slider>().value - 1, 0, 100);
                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                
                    
                    //SettingSliders.transform.GetChild(0).GetComponent<Slider>().value++;
                    SettingSliders.transform.GetChild(1).GetComponent<Slider>().value = Mathf.Clamp(SettingSliders.transform.GetChild(1).GetComponent<Slider>().value + 1, 0, 100);
                
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    //AudioControl.setMusicVol(SettingSliders.transform.GetChild(1).GetComponent<Slider>().value);
                    AudioSettings.setMusicVol(SettingSliders.transform.GetChild(1).GetComponent<Slider>().value);
                    lastStep = Time.time;
                    OnMusic = false;
                    screen = States.Settings;
                }
            }
        }
    }

    void SettingPicking()
    {
        if (!OnSound && !OnMusic)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    Settings.transform.GetChild(SettingButtonChosen).GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
                    SettingButtonChosen--;
                    if (SettingButtonChosen < 0)
                        SettingButtonChosen = MaxSettingButtons;
                    Settings.transform.GetChild(SettingButtonChosen).GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f);
                   // Debug.Log(MenuButtonChosen);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    Settings.transform.GetChild(SettingButtonChosen).GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
                    SettingButtonChosen++;
                    if (SettingButtonChosen > MaxSettingButtons)
                        SettingButtonChosen = 0;
                    Settings.transform.GetChild(SettingButtonChosen).GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f);
                    //Debug.Log(MenuButtonChosen);
                }
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                if (Time.time - lastStep > timeBetweenSteps)
                {
                    lastStep = Time.time;
                    switch (SettingButtonChosen)
                    {
                        case 0:
                            //Debug.Log("Selected settings 1");
                            OnSound = true;
                            break;
                        case 1:
                            //Debug.Log("Selected settings 2");
                            OnMusic = true;
                            break;
                        case 2:
                           // Debug.Log("Back to Menu");
                            Settings.transform.GetChild(SettingButtonChosen).GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f);
                            screen = States.Menu;
                            break;
                        case 3:
                            break;
                    }
                }
            }
        }
    }

    void ScreenUpdate()
    {
        if(screen == States.Start)
        {
            pressstarttext.SetActive(true);
            MenuButtons.SetActive(false);
            Settings.SetActive(false);
            Credits.SetActive(false);
            SettingSliders.SetActive(false);
            StartUpdate();
        }
        if(screen == States.Settings)
        {
            pressstarttext.SetActive(false);
            MenuButtons.SetActive(false);
            Settings.SetActive(true);
            Credits.SetActive(false);
            SettingSliders.SetActive(true);
            SettingsUpdate();
        }
        if(screen == States.Menu)
        {
            pressstarttext.SetActive(false);
            MenuButtons.SetActive(true);
            Settings.SetActive(false);
            Credits.SetActive(false);
            SettingSliders.SetActive(false);
            MenuUpdate();
        }
        if(screen == States.Credits)
        {
            pressstarttext.SetActive(false);
            MenuButtons.SetActive(false);
            Settings.SetActive(false);
            Credits.SetActive(true);
            SettingSliders.SetActive(false);
            CreditsUpdate();
        }
    }
}
