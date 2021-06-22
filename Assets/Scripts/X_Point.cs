using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_Point : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            PlayerPrefs.SetString("X_Point", this.gameObject.name);

            Debug.Log("x" + this.gameObject.name);

        }
    }
  
}
