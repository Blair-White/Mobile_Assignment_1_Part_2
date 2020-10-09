using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{

    private int throttle,timer,state;
    private bool isInit, isInstructions;
    public GameObject button1, button2, title, panel,instructions,tapanywhere;
    public AudioSource mAudioSource;
    public AudioClip mAudioClip;
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (0):
                timer++;
                if (timer > 120)
                {
                    title.SetActive(true);
                    state++;
                    timer = 0;
                }

                break;

            case (1):
                timer++;
                if (timer > 65)
                {
                    button1.SetActive(true);
                    state++;
                    timer = 0;
                }

                break;

            case (2):
                timer++;
                if (timer > 45)
                {
                    button2.SetActive(true);
                    state++;
                    timer = 0;
                }
                break;

            case (3):
                if(isInstructions)
                {
                    throttle++;
                    if(throttle > 140)
                    {
                        tapanywhere.SetActive(true);
                        if (Input.GetMouseButtonDown(0))
                        {
                            EndInstruction();
                            title.SetActive(true);
                            button1.SetActive(true);
                            button2.SetActive(true);
                            instructions.SendMessage("FadeOut");
                            tapanywhere.SetActive(false);
                            throttle = 0;
                            mAudioSource.PlayOneShot(mAudioClip);
                        }
                    }
                }    
                break;

            case (4):
                throttle++;
                if (throttle>=300)
                {

                    SceneManager.LoadScene(2);
                }

                break;

            default:
                break;
        }

    }

    void StartInstructions() { isInstructions = true; }
    void EndInstruction() { isInstructions = false; }

    void StartGame() { state = 4; throttle = 0; }
}
