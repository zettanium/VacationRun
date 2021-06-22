using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumps : MonoBehaviour
{
    public float jumph;
    public float jumpforce;
    private Vector3 jump;
    private Rigidbody rigg;
    private bool isgrounded;
    



    void Start()
    {
        jump = new Vector3(0f, jumph, 0f);
        rigg= GetComponent<Rigidbody>();
       
        //  col = GetComponent<BoxCollider>();

    }

    void Update()
    {
    


        if (Input.GetKeyDown(KeyCode.Space)&& isgrounded)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            //rigg.AddForce(transform.up * m_Thrust);

            

            rigg.AddForce(jump * jumpforce, ForceMode.Acceleration);
            isgrounded = false;
            Debug.Log("Space BAsıldııı");
            travelator.ziplama = true;
           

        
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            isgrounded = true;
          
        }
    }

    private void FixedUpdate()
    {
        //transform.Rotate(0,Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f,0);
        //transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * 5.0f, 0);

      
    }
}  
