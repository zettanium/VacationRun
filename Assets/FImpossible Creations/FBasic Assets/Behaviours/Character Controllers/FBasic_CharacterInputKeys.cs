using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace FIMSpace.Basics
{
    /// <summary>
    /// FM: Basic character movement input for hard coded keys
    /// </summary>
   
    public class FBasic_CharacterInputKeys : FBasic_CharacterInputBase
    {
        public GameObject Gameover_Menu;
        public GameObject Finish_Panel;
        public ParticleSystem gems_particle;
        public ParticleSystem crash_particle;
        public Text Finish_Gem_Text;
        public Text GemsText;
        public Text X_text;
        public static bool GameOvers;

      


        protected override void Update()
        {
            Vector2 inputValue = Vector2.zero;
           // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetTouch(0).deltaPosition.x < 0) inputValue.x = -2; else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetTouch(0).deltaPosition.x > 0) inputValue.x = 2;
 
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) inputValue.x = -1; else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) inputValue.x = 1;
            if (!Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) inputValue.y = 1; else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) inputValue.y = -1;


            //Mobile Touch Controller
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.x >0)
            {
                inputValue.x = inputValue.x + 0.5F;
       
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.x < 0)

            {
                inputValue.x = inputValue.x - 0.5F;

            }
            SetInputAxis(inputValue);
            //SetInputDirection(Camera.main.transform.eulerAngles.y); //Karakteri kamera açısına doğru yönlendirme kodu
            if (Input.GetKeyDown(KeyCode.Space)) Jump();



            if(GameOvers==true)
            {
                GameOver();
            }
        }



        private void OnTriggerEnter(Collider other)
        {

            //   ContactPoint contact = Collider.;
            if (other.gameObject.tag == "Jump_Obj")
            {
                Jump();
                Debug.Log("Jump");
            }

            if (other.gameObject.tag == "SpeedUP")
            {
                FBasic_FheelekController.turbo_enabled = true;
                Debug.Log("SpeedUP");

                Destroy(other.gameObject);
                StartCoroutine(ExampleCoroutine01());
                IEnumerator ExampleCoroutine01()
                {
                    yield return new WaitForSeconds(1f);

                    FBasic_FheelekController.turbo_enabled = false;

                }
               
            }

            if (other.gameObject.tag == "Gems")
            {
                gems_particle.Play();
                Destroy(other.gameObject);
                Debug.Log("Gems");
               
                PlayerPrefs.SetInt("Gem_Sum", PlayerPrefs.GetInt("Gem_Sum")+1);
                GemsText.text = PlayerPrefs.GetInt("Gem_Sum").ToString();
            }


            if (other.gameObject.tag == "Gameover" || other.gameObject.tag == "Enemy")
            {
                GameOver();
            }

            


            if (other.gameObject.tag == "Finish")
            {
                gems_particle.Play();
                Finish_Panel.SetActive(true);
                X_text.text = PlayerPrefs.GetString("X_Point");
                Finish_Gem_Text.text = PlayerPrefs.GetInt("Gem_Sum").ToString();
                //GameObject.FindGameObjectWithTag("Player").SetActive(false);
                Debug.Log("Finish");
                kamera_takip.FinishStatus = true;

            }


        }

        public void GameOver()
        {
            Gameover_Menu.SetActive(true);
           // crash_particle.Play();
            kamera_takip.GameOvers = true;
            Debug_Menu.MaxSpeedChange = 0;

            StartCoroutine(ExampleCoroutine02());
            IEnumerator ExampleCoroutine02()
            {
                yield return new WaitForSeconds(1f);
               // GameObject.FindGameObjectWithTag("Player").SetActive(false);
               // Destroy(GameObject.FindGameObjectWithTag("Player"));

            }
           
        }
    }
}
