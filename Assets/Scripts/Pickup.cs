using System.Collections;
using System.Collections.Generic;
using FIMSpace.Basics;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour

{
    public GameObject bavul;
    public GameObject bavul_renk;
    public GameObject shoes1,sapka1,tshirt1,DressL,DressS;
    public ParticleSystem Pickup_Particle;
    public static float Toplam_Kg;
    public Text kg_yazi;
    public static bool agir_tasima;
    public Material Red;
    public Material Pink;
    public ParticleSystem bavul_patlama;
    public static bool bavul_patladi;
    public GameObject patlayan_esyalar;
    public GameObject puan_text;
    public Text puan_yazi;

    public GameObject puan_red;
    public Text puan_reds;
    public TextMesh text3D;
    public GameObject gosterge;
    public float max_kg;

    public void Start()
    {
        yan_son();
        max_kg = 30;
        Toplam_Kg = 0;
        text3D.text = Toplam_Kg.ToString() + " / " + max_kg;

    }

   

    public void Update()
        
    {

        kg_yazi.text = Toplam_Kg.ToString() + " KG";

        if (Toplam_Kg >= (max_kg+5))
        {
            bavul_patladi = true;
            patlayan_esyalar.SetActive(true);
            bavul_patlama.Play();
            Pickup_Particle.Play();
            Debug.Log("Bavul Patladı");
            FBasic_CharacterInputKeys.GameOvers = true;
            Debug_Menu.MaxSpeedChange = 0;

            bavul_renk.GetComponent<Renderer>().material = Red;

        }
        else if (Toplam_Kg >= 25 && Toplam_Kg < (max_kg+5))
        {
            agir_tasima = true;

            yan_son();

        }
        else
        {
            agir_tasima = false;

            bavul_renk.GetComponent<Renderer>().material = Pink;
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        //   ContactPoint contact = Collider.;
        if (other.gameObject.name == "shoes1")
        {
            shoes1.SetActive(true);

            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "sapka1")
        {
            sapka1.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "TPShirtAL")
        {
            tshirt1.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "TPFDressS")
        {
            DressS.SetActive(true);
            DressL.SetActive(false);
            Destroy(other.gameObject);
        }




        if (other.gameObject.tag == "gerekli_esya")
        {
            bavul.transform.localScale += new Vector3(0.011f, 0.0001F, 0.0006f);
            Pickup_Particle.Play();
            StartCoroutine(ExampleCoroutine01());
            Toplam_Kg +=1;

            text3D.text= Toplam_Kg.ToString() + " / " + max_kg;

            puan_text.SetActive(true);
            puan_yazi.text = "+1";
            gosterge.transform.localScale += new Vector3(0f, 5f, 0f);
            IEnumerator ExampleCoroutine01()
            {
                yield return new WaitForSeconds(0.15f);
                bavul.transform.localScale += new Vector3(-0.010f, -0.000091F, -0.00055f);
                yield return new WaitForSeconds(0.15f);
                puan_text.SetActive(false);
            }
            Destroy(other.gameObject);
            Debug.Log("Bavul Büyüdü");
        }

        if (other.gameObject.tag == "gereksiz_esya")
        {

           
            bavul.transform.localScale += new Vector3(0.0012f, 0, 0.0008f);
            Pickup_Particle.Play();
            StartCoroutine(ExampleCoroutine01());
            Toplam_Kg +=3;
            puan_red.SetActive(true);
            text3D.text = Toplam_Kg.ToString() + " / " + max_kg;
            puan_reds.text = "+3";
            IEnumerator ExampleCoroutine01()
            {
                yield return new WaitForSeconds(0.15f);
                bavul.transform.localScale += new Vector3(-0.0009f, 0, -0.00072f);
                yield return new WaitForSeconds(0.15f);
                puan_red.SetActive(false);
            }
            Destroy(other.gameObject);
            Debug.Log("Bavul Gereksiz Büyüdü");
        }



        if (other.gameObject.tag == "bavul_bosalt")
        {

            Toplam_Kg -= 5;
            bavul.transform.localScale -= new Vector3(0.0035f, 0, 0.00025f);
        }
       
    }
    public void yan_son()
    {
        bavul_renk.GetComponent<Renderer>().material = Red;

        StartCoroutine(ExampleCoroutine03());

        IEnumerator ExampleCoroutine03()
        {
            yield return new WaitForSeconds(0.25f);
            bavul_renk.GetComponent<Renderer>().material = Pink;
        }
    }
}
