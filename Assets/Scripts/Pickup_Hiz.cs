using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Hiz : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (other.gameObject.tag == "Jump_Obj")
        {
            
            Debug.Log("Jump");

         
        }


    }
}
