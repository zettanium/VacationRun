using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esya_Cekis : MonoBehaviour
{

    public float thrust = 5.0f;
    public Rigidbody rb;
    void Start()
    {
    
    }
    void Update()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(thrust, 0, 0, ForceMode.Impulse);
    }
}
