using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;

    public static float speed = 20;
    public static float speed2 = 11;
    [SerializeField] Rigidbody rb;

 float horizontalInput;
  [SerializeField] float horizontalMultiplier = 2;

   public float speedIncreasePerPoint = 0.1f;

    public Text positions;
    

    public void Start()
    {
       
    }

    private void FixedUpdate ()
    {




        Vector3 tempos = transform.position;
        //  if (!alive) return;

         Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

#if UNITY_EDITOR

        //  if(transform.position.x<5.00f && transform.position.x > -8.85f) { 
        Vector3 horizontalMove = transform.right * horizontalInput * speed2 * Time.fixedDeltaTime * horizontalMultiplier;
       rb.MovePosition(rb.position + forwardMove + horizontalMove);
        /* }
         else
         {
             if (transform.position.x >= 5.00f)
             {

                 tempos.x = 4.94f;
             }
             else if (transform.position.x >= -8.24f)
             {
                 tempos.x = -8.24f;
             }
         }*/
#endif





    }

    /*
    public void Jumper()
    {
        Vector3 forwardUp = transform.up* 500 * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardUp);
    }
    */

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, speed * Time.fixedDeltaTime);

#if MOBILE_INPUT



        Vector3 sag_git = new Vector3(4.93f, transform.position.y, transform.position.z);
        Vector3 sol_git = new Vector3(-7.78f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
           

            Touch parmak = Input.GetTouch(0);
            positions.text = parmak.deltaPosition.ToString();


            transform.position = new Vector3(Input.touchCount * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            
               // transform.position = Vector3.Lerp(transform.position, sag_git, 10 * Time.fixedDeltaTime);
            
            
                //transform.position = Vector3.Lerp(transform.position, sol_git, 10 * Time.fixedDeltaTime);
            

        }

#endif
    }

 

  
    }