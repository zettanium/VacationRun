using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_Menu : MonoBehaviour
{
   
    public static float MaxSpeedChange=35f;
    public Material Road1,Road2,Road3,Road4,Road5;
    [Header("Items Group")]
    public GameObject Gems_Group;
    public GameObject Jumpers_Group;
    public GameObject JumpCheck;
    public GameObject SpeedCheck;
    public GameObject SpeedUP_Group;
    public GameObject Debug_Menu_Panel;
    public Text SpeedCount;

    void Start()
    {
        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Road"))
        {
            if (PlayerPrefs.GetInt("RoadMat") == 1)
                ObjectFound.GetComponent<Renderer>().material = Road1;
            else if (PlayerPrefs.GetInt("RoadMat") == 2)
                ObjectFound.GetComponent<Renderer>().material = Road2;
            else if (PlayerPrefs.GetInt("RoadMat") == 3)
                ObjectFound.GetComponent<Renderer>().material = Road3;
            else if (PlayerPrefs.GetInt("RoadMat") == 4)
                ObjectFound.GetComponent<Renderer>().material = Road4;
            else if (PlayerPrefs.GetInt("RoadMat") == 5)
                ObjectFound.GetComponent<Renderer>().material = Road5;
            else
            {
                ObjectFound.GetComponent<Renderer>().material = Road1;
                PlayerPrefs.SetInt("RoadMat", 1);
            }
        }


        if (PlayerPrefs.GetInt("CamChange") == 1)
            kamera_takip.CamChange = 1;
        else if (PlayerPrefs.GetInt("CamChange") == 2)
            kamera_takip.CamChange = 2;
        else if (PlayerPrefs.GetInt("CamChange") == 0)
            kamera_takip.CamChange = 1;


        if (PlayerPrefs.GetInt("Jumpers") == 1)
        {
            Jumpers_Group.SetActive(false);
            JumpCheck.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Jumpers") == 2)
        {
            Jumpers_Group.SetActive(true);
            JumpCheck.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Jumpers")==0)
        {
            Jumpers_Group.SetActive(true);
            JumpCheck.SetActive(true);
        }





        if (PlayerPrefs.GetInt("SpeedUps") == 1)
        {
            SpeedUP_Group.SetActive(false);
            SpeedCheck.SetActive(false);
           
        }
        else if (PlayerPrefs.GetInt("SpeedUps") == 2)
        {
            SpeedUP_Group.SetActive(true);
            SpeedCheck.SetActive(true);

        }
        else if(PlayerPrefs.GetInt("SpeedUps") == 0)
        {
            SpeedUP_Group.SetActive(true);
            SpeedCheck.SetActive(true);

        }


    }

   
    void Update()
    {
        if (Debug_Menu_Panel.activeSelf) {   
        MaxSpeedChange = GameObject.Find("SpeedSlider").GetComponent<Slider>().value;
        SpeedCount.text = GameObject.Find("SpeedSlider").GetComponent<Slider>().value.ToString();
        }
    }

    public void CameraChanges()
    {
  

        if (PlayerPrefs.GetInt("CamChange") == 1)
              { kamera_takip.CamChange = 2;
                PlayerPrefs.SetInt("CamChange", 2);
              }
        else if (PlayerPrefs.GetInt("CamChange") == 2)
              {
                kamera_takip.CamChange = 1;
                PlayerPrefs.SetInt("CamChange", 1);
              }
        else if (PlayerPrefs.GetInt("CamChange") == 0)
        {
            kamera_takip.CamChange = 1;
            PlayerPrefs.SetInt("CamChange", 1);
        }

    }


    public void Gems()
    {

        if (PlayerPrefs.GetInt("Gems") == 0)
        {
            Gems_Group.SetActive(true);
            PlayerPrefs.SetInt("Gems", 1);
        }
        else if (PlayerPrefs.GetInt("Gems") == 1)
        {
            Gems_Group.SetActive(false);
            PlayerPrefs.SetInt("Gems", 1);
        }

    }


    public void JumperOnOff()
    {

        if (PlayerPrefs.GetInt("Jumpers") == 1)
        {
            Jumpers_Group.SetActive(true);
            JumpCheck.SetActive(true);
            PlayerPrefs.SetInt("Jumpers", 2);
        }
        else if (PlayerPrefs.GetInt("Jumpers") == 2)
        {
            Jumpers_Group.SetActive(false);
            JumpCheck.SetActive(false);
            PlayerPrefs.SetInt("Jumpers", 1);
        }
        else if (PlayerPrefs.GetInt("Jumpers") == 0)
        {
            Jumpers_Group.SetActive(false);
            JumpCheck.SetActive(false);
            PlayerPrefs.SetInt("Jumpers", 1);
        }

    }


    public void SpeedUPOnOff()
    {

        if (PlayerPrefs.GetInt("SpeedUps") == 1)
        {
            SpeedUP_Group.SetActive(true);
            SpeedCheck.SetActive(true);
            PlayerPrefs.SetInt("SpeedUps", 2);
        }
        else if (PlayerPrefs.GetInt("Jumpers") == 2)
        {
            SpeedUP_Group.SetActive(false);
            SpeedCheck.SetActive(false);
            PlayerPrefs.SetInt("SpeedUps", 1);
        }
        else if (PlayerPrefs.GetInt("Jumpers") == 0)
        {
            SpeedUP_Group.SetActive(false);
            SpeedCheck.SetActive(false);
            PlayerPrefs.SetInt("SpeedUps", 1);
        }

    }

    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Debug_Menu_Open()
    {
        Debug_Menu_Panel.SetActive(true);  
    }
    public void Debug_Menu_Close()
    {
        Debug_Menu_Panel.SetActive(false);
    }
    public void MaterialChanged()
    {  //All Roads Material Changed

        if (PlayerPrefs.GetInt("RoadMat") == 1)
            foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Road"))
            {
                PlayerPrefs.SetInt("RoadMat", 2);
                ObjectFound.GetComponent<Renderer>().material = Road2;
            }
        else if (PlayerPrefs.GetInt("RoadMat") == 2)
            foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Road"))
            {
                PlayerPrefs.SetInt("RoadMat", 3);
                ObjectFound.GetComponent<Renderer>().material = Road3;
            }
        else if (PlayerPrefs.GetInt("RoadMat") == 3)
            foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Road"))
            {
                PlayerPrefs.SetInt("RoadMat", 4);
                ObjectFound.GetComponent<Renderer>().material = Road4;
            }
        else if (PlayerPrefs.GetInt("RoadMat") == 4)
            foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Road"))
            {
                PlayerPrefs.SetInt("RoadMat", 1);
                ObjectFound.GetComponent<Renderer>().material = Road1;
            }


    
    }
}
