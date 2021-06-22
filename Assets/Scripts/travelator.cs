using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using FIMSpace.Basics;

public class travelator : MonoBehaviour
{
    public Animator animator,Plaj_Anim;
    public bool yuruyen_band_aktif=false;
    public bool yuruyen_band_aktif_duz = false;
    public static bool ziplama;
    public float mass;
    public Rigidbody rb;
    public Text GemsText;
    public ParticleSystem GemsParticle;
    public ParticleSystem PoofParticle;
    public bool dusus;
    public GameObject Bavul;
    public Animation Bavul_Anim;
    public GameObject confeti,firework,tartidaki_bavul;
    public GameObject kg_yazi;
    public string kgsi;
    public GameObject Taptap;
    public GameObject karakter;
    public static bool Finish_Active;
    public GameObject Finish_Cam,plaj_cam;
    public GameObject cekilen_objeler;
    public GameObject PlayerBad, PlayerGood,Happy,Sad;
    public TextMesh Finish_Terazi;

    void Start()


    {
        Finish_Active = false;
        FBasic_CharacterInputKeys.GameOvers = false;
    
        GemsText.text = PlayerPrefs.GetInt("Gem_Sum").ToString();
        ziplama = false;
        animator = GetComponent<Animator>();
        PlayerMovement.speed = 20;

       Debug_Menu.MaxSpeedChange = 35;

    }

    // Update is called once per frame
    void Update()
    {
        if(Pickup.agir_tasima==true && FBasic_CharacterInputKeys.GameOvers == false && Finish_Active==false && dusus==false)
        {
            animator.SetBool("agir_cekis", true);

            animator.SetBool("tekrar_kos", false);
            karakter.transform.rotation = Quaternion.Euler(0, 180, 0);
 
           karakter.transform.position = new Vector3(transform.position.x + 0.98f, transform.position.y, transform.position.z + 0.95f);
            Debug_Menu.MaxSpeedChange = 18;
        }
        else if(Pickup.agir_tasima==false && yuruyen_band_aktif==false && FBasic_CharacterInputKeys.GameOvers == false && Finish_Active == false && dusus==false &&yuruyen_band_aktif_duz==false)
        {//
            
            animator.SetBool("tekrar_kos", true);
            animator.SetBool("agir_cekis", false);
            karakter.transform.rotation = Quaternion.Euler(0, 0, 0);
            karakter.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Debug_Menu.MaxSpeedChange = 35;
        }

      else if(FBasic_CharacterInputKeys.GameOvers == true)
        {
            animator.gameObject.GetComponent<Animator>().enabled = false;
            animator.SetBool("dusus1", true);
            animator.gameObject.GetComponent<Animator>().enabled = enabled;
            animator.SetBool("kalkis", false);
            // animator.SetBool("dusus1", true);
        }

        if (yuruyen_band_aktif==true && Finish_Active == false)
        {
          if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");

                Debug_Menu.MaxSpeedChange = Debug_Menu.MaxSpeedChange + 2;
                PlayerMovement.speed = PlayerMovement.speed + 2;
                // animator.SetBool("Run", true);
            }
          else
            {

                Debug_Menu.MaxSpeedChange = Debug_Menu.MaxSpeedChange - 0.22f;
                PlayerMovement.speed = PlayerMovement.speed - 0.2f;
               // animator.SetBool("Slow", true);
                if (Debug_Menu.MaxSpeedChange <= 10) {
                 //   animator.SetBool("Slow", true);
                  //  animator.SetBool("Run", false);
                }

                else
                {
                 // animator.SetBool("Run", true);
                //  animator.SetBool("Slow", false);
                }
               
            }

        }
        else { //animator.SetBool("Run", true);
           // animator.SetBool("Slow", false);
        }


    }



    private void OnTriggerEnter(Collider other)
    {

        //   ContactPoint contact = Collider.;
        if ((other.gameObject.tag == "yuruyen_band" || other.gameObject.tag == "tr_giris") && dusus==false)
        {
            Debug.Log("Trden Girdi Speed 10");
            Debug_Menu.MaxSpeedChange = 10;
            PlayerMovement.speed = 10;
            yuruyen_band_aktif = true;
            Taptap.SetActive(true);
            
        }


        if ((other.gameObject.tag == "yuruyen_band_duz" || other.gameObject.tag == "tr_giris_duz") && dusus == false)
        {
            Debug.Log("Trden Girdi Speed 30");
            Debug_Menu.MaxSpeedChange = 60;
            PlayerMovement.speed = 30;
            yuruyen_band_aktif_duz = true;

        }


        if (other.gameObject.tag == "tr_cikis")
        {
            Debug.Log("Trden Cikti");
            PlayerMovement.speed = 20;
            Debug_Menu.MaxSpeedChange = 35;
            yuruyen_band_aktif = false;
            animator.SetBool("kalkis", true);
            animator.SetBool("dusus1", false);
            Taptap.SetActive(false);
        }


        if (other.gameObject.tag == "cukur")
        {
            Debug.Log("Cukura düşüldü");
            Debug_Menu.MaxSpeedChange = 0;
            PlayerMovement.speed = 0;
            // PlayerMovement.speed = 1;
            // animator.SetBool("Run", false);
            animator.SetBool("", false);
            animator.SetBool("dusus_cukur", true);
            rb = GetComponent<Rigidbody>();
            rb.mass =0.0f;

        }


        if (other.gameObject.tag == "Gems")
        {
            //gems_particle.Play();
            Destroy(other.gameObject);
            Debug.Log("Gems");
            GemsParticle.Play();

            PlayerPrefs.SetInt("Gem_Sum", PlayerPrefs.GetInt("Gem_Sum") + 1);
            GemsText.text = PlayerPrefs.GetInt("Gem_Sum").ToString();
           
        }
        if (other.gameObject.tag == "Finish")
        {
            Finish_Active = true;
            Debug_Menu.MaxSpeedChange = 0;
            PlayerMovement.speed = 0;
            animator.SetBool("finish_sevinme", true);
           
            Bavul_Anim.gameObject.GetComponent<Animation>().enabled = false;
            // Bavul.transform.position = new Vector3(3.05f , 2.94f , 141.66f );
            // Bavul.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            tartidaki_bavul.SetActive(true);
            confeti.SetActive(true);
            firework.SetActive(true);
            Bavul.SetActive(false);

            
            Finish_Cam.SetActive(true);
            Level_Manager.Main_Cam_Aktif = false;
             animator.SetBool("dusus1", false);
            Finish_Terazi.text = Pickup.Toplam_Kg.ToString()+" KG";

            if (Pickup.Toplam_Kg < 15)
            {
                PlayerBad.SetActive(true);
                Sad.SetActive(true);

            }
            else
            {
                PlayerGood.SetActive(true);
                Happy.SetActive(true);
            }

            StartCoroutine(ExampleCoroutine08());
            IEnumerator ExampleCoroutine08()
            {

                yield return new WaitForSeconds(2.3f);

                plaj_cam.SetActive(true);
                Finish_Cam.SetActive(false);
                Plaj_Anim.SetBool("Finish", true);
               

            }


        }


        if (other.gameObject.tag == "bavul_bosalt")
        {
            cekilen_objeler.SetActive(true);

            StartCoroutine(ExampleCoroutine08());
            IEnumerator ExampleCoroutine08()
            {

                yield return new WaitForSeconds(1f);

                cekilen_objeler.SetActive(false);

            }
        }

            if (other.gameObject.tag == "engel_top")
        {
            //gems_particle.Play();
            //Destroy(other.gameObject);
            dusus = true;
            Debug.Log("Engel 1");
            Debug_Menu.MaxSpeedChange = 0;
            PlayerMovement.speed = 0;
            animator.SetBool("dusus1", true);
            animator.SetBool("kalkis", false);
            
            

            StartCoroutine(ExampleCoroutine01());
            IEnumerator ExampleCoroutine01()
            {

                yield return new WaitForSeconds(2.3f);
                dusus = false;

                animator.SetBool("dusus1", false);
                animator.SetBool("kalkis", true);


                if(yuruyen_band_aktif==true)
                { Debug_Menu.MaxSpeedChange = 10; }
                else { Debug_Menu.MaxSpeedChange = 35;
                    PlayerMovement.speed = 20;
                }
                yuruyen_band_aktif = false;
                
               
            }          
          
        }
        }


}
