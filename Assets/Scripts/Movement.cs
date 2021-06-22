using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 20;
    float speed2 = 11;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, speed * Time.fixedDeltaTime);

        Vector3 sag_git = new Vector3(2.05f, transform.position.y, transform.position.z);
        Vector3 sol_git = new Vector3(-2f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {


            Touch parmak = Input.GetTouch(0);
            
            if (parmak.deltaPosition.x > 80.0f)
            {
                transform.position = Vector3.Lerp(transform.position, sag_git, 8 * Time.fixedDeltaTime);
               // transform.rotation *= Quaternion.AngleAxis(Input.GetTouch(0).deltaPosition.x, Vector3.forward);
            }
            else if (parmak.deltaPosition.x < -80.0f)
            {
                transform.position = Vector3.Lerp(transform.position, sol_git, 8 * Time.fixedDeltaTime);
               // transform.rotation *= Quaternion.AngleAxis(Input.GetTouch(0).deltaPosition.x, Vector3.forward);
            }

        }
    }
}
