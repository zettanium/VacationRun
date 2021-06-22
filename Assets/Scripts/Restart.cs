using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }


    public void RestartButton2()
    {
        SceneManager.LoadScene(1);
    }
}
