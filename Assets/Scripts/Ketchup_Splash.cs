using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ketchup_Splash : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem splash;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {

        //   ContactPoint contact = Collider.;
        if (other.gameObject.tag == "Player")
        {
            splash.Play();

        }


    }
}
