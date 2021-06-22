using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;


public class Level_Manager : MonoBehaviour
{

    public GameObject Start_Cam;
    public GameObject MainCamera;
    public static bool Main_Cam_Aktif,Player_Active;
    public GameObject Player;
    // Start is called before the first frame update

    private void Awake()
    {
        // Initialize CLIK
        TTPCore.Setup();
        // Your code here
    }


    void Start()
    {
        Debug_Menu.MaxSpeedChange = 0;
        MainCamera.SetActive(false);

        Main_Cam_Aktif = false;
        Player.SetActive(false);
        Player_Active = false;
    
        Start_Cam.SetActive(true);
        StartCoroutine(ExampleCoroutine01());
        IEnumerator ExampleCoroutine01()
        {
            yield return new WaitForSeconds(4.6f);
            Start_Cam.SetActive(false);
            MainCamera.SetActive(true);
            Main_Cam_Aktif = true;
            Player.SetActive(true);
            Player_Active = true;
            Debug_Menu.MaxSpeedChange = 35;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Main_Cam_Aktif==false)
        {
            MainCamera.SetActive(false);
            
        }
        
    }
}
