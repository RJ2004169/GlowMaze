using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    private States currentState;
    private PlayState Play;
    private StartState Menu;
    private PauseState Pause;
    private FinishState Finish;
    private GameOverState GameOver;
    private float timer;
    private float highScore;
    private int finishFlag;
    private GameObject[] startScreenElements;
    private GameObject[] pauseScreenElements;
    private GameObject[] gameOverScreenElements;
    private GameObject[] finishScreenElements;


    public Light spotLightControl;
    public Light pointLightControl;
    public Canvas uiScreen;
    public Camera camControl;
    public GameObject playerControl;

    

    public void Start()
    {
        Menu = new StartState();
        Play = new PlayState();
        Pause = new PauseState();
        GameOver = new GameOverState();
        Finish = new FinishState();


        startScreenElements = GameObject.FindGameObjectsWithTag("StartScreen");
        pauseScreenElements = GameObject.FindGameObjectsWithTag("PauseScreen");
        gameOverScreenElements = GameObject.FindGameObjectsWithTag("GameOverScreen");
        finishScreenElements = GameObject.FindGameObjectsWithTag("FinishScreen");
        timer = 0.0f;
        highScore = 100.0f;
        finishFlag = 0;
        SetState(Menu);
    }

    public void SetState( States newState)
    {
        currentState = newState;
        StartCoroutine(newState.Start());
    }

    public void HealthRecharge()
    {
        currentState.playerHealth = 100;
    }

    public void OnStartButtonClicked()
    {
        Play.playerHealth = 100;
        timer = 0;
        finishFlag = 0;
        playerControl.transform.position = new Vector3(19.89f, 0, 19.87f);
        playerControl.transform.rotation = Quaternion.identity;
        SetState(Play);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireBug")
        {
            other.gameObject.SetActive(false);
            HealthRecharge();
            
        }

        if(other.tag == "Finish")
        {
            SetState(Finish);
        }
       
    }


    public void Update()
    {
        //toggle audio depending on state
        if(currentState.toggleAudio && !camControl.GetComponent<AudioSource>().isPlaying)
        {
            camControl.GetComponent<AudioSource>().Play();
        }
        else if(!currentState.toggleAudio)
        {
            camControl.GetComponent<AudioSource>().Pause();
        }

        //enable or disable ui elements based on state
        if(currentState.uiEnabled)
        {
            uiScreen.enabled = true;
            switch (currentState.stateIndex)
            {

                case 0:
                    //uiElementsArray = GameObject.FindGameObjectsWithTag("StartScreen");
                    foreach(GameObject uiGO in startScreenElements)
                    {
                        uiGO.SetActive(true);
                    }
                    foreach (GameObject uiGO in pauseScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in gameOverScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in finishScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    break;
                case 2:
                    //uiElementsArray = GameObject.FindGameObjectsWithTag("StartScreen");
                    foreach (GameObject uiGO in startScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in pauseScreenElements)
                    {
                        uiGO.SetActive(true);
                    }
                    foreach (GameObject uiGO in gameOverScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in finishScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    break;
                case 3:
                    //uiElementsArray = GameObject.FindGameObjectsWithTag("StartScreen");
                    foreach (GameObject uiGO in startScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in pauseScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in gameOverScreenElements)
                    {
                        uiGO.SetActive(true);
                    }
                    foreach (GameObject uiGO in finishScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    break;
                case 4:
                    //uiElementsArray = GameObject.FindGameObjectsWithTag("StartScreen");
                    foreach (GameObject uiGO in startScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in pauseScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in gameOverScreenElements)
                    {
                        uiGO.SetActive(false);
                    }
                    foreach (GameObject uiGO in finishScreenElements)
                    {
                        uiGO.SetActive(true);
                    }
                    break;
                //case 2:
                //    GameObject[] uiElementsArray2 = GameObject.FindGameObjectsWithTag("StartScreen");
                //    foreach (GameObject uiGO in uiElementsArray2)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    uiElementsArray2 = GameObject.FindGameObjectsWithTag("PauseScreen");
                //    foreach (GameObject uiGO in uiElementsArray2)
                //    {
                //        uiGO.SetActive(true);
                //    }
                //    uiElementsArray2 = GameObject.FindGameObjectsWithTag("GameOverScreen");
                //    foreach (GameObject uiGO in uiElementsArray2)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    uiElementsArray2 = GameObject.FindGameObjectsWithTag("FinishScreen");
                //    foreach (GameObject uiGO in uiElementsArray2)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    break;
                //case 3:
                //    GameObject[] uiElementsArray3 = GameObject.FindGameObjectsWithTag("StartScreen");
                //    foreach (GameObject uiGO in uiElementsArray3)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    uiElementsArray3 = GameObject.FindGameObjectsWithTag("PauseScreen");
                //    foreach (GameObject uiGO in uiElementsArray3)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    uiElementsArray3 = GameObject.FindGameObjectsWithTag("GameOverScreen");
                //    foreach (GameObject uiGO in uiElementsArray3)
                //    {
                //        uiGO.SetActive(true);
                //    }
                //    uiElementsArray3 = GameObject.FindGameObjectsWithTag("FinishScreen");
                //    foreach (GameObject uiGO in uiElementsArray3)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    break;
                //case 4:
                //    GameObject[] uiElementsArray4 = GameObject.FindGameObjectsWithTag("StartScreen");
                //    foreach (GameObject uiGO in uiElementsArray4)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    uiElementsArray4 = GameObject.FindGameObjectsWithTag("PauseScreen");
                //    foreach (GameObject uiGO in uiElementsArray4)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    uiElementsArray4 = GameObject.FindGameObjectsWithTag("GameOverScreen");
                //    foreach (GameObject uiGO in uiElementsArray4)
                //    {
                //        uiGO.SetActive(false);
                //    }
                //    uiElementsArray4 = GameObject.FindGameObjectsWithTag("FinishScreen");
                //    foreach (GameObject uiGO in uiElementsArray4)
                //    {
                //        uiGO.SetActive(true);
                //    }
                //    break;
                default:
                    break;
            }

            camControl.transform.position = currentState.cameraPosition;
            camControl.transform.rotation = Quaternion.Euler(currentState.cameraRotation);
        }
        else
        {
            uiScreen.enabled = false;
            camControl.transform.position = currentState.cameraPosition;
            camControl.transform.rotation = Quaternion.Euler(currentState.cameraRotation);
            //camControl.transform.position = playerControl.transform.position - playerControl.transform.forward * 6;
            //camControl.transform.LookAt(playerControl.transform);
            //camControl.transform.Rotate(new Vector3(45, 0, 0));
            //camControl.transform.position = new Vector3(camControl.transform.position.x, camControl.transform.position.y + 10.5, camControl.transform.position.z);

        }
        
        //update for each state
        switch (currentState.stateIndex)
        {
            case 0:
                //Start State

                //Stop player walk animation
                playerControl.GetComponent<Animator>().SetBool("isWalk", false);

                //Turn off Spot Light
                spotLightControl.enabled = currentState.spotLightEnabled;
                

                break;
            case 1:
                //Play State

                //Updating camera position wrt player
                currentState.cameraPosition = new Vector3(playerControl.transform.position.x, playerControl.transform.position.y + 10.5f, playerControl.transform.position.z-6);

                //health reduction
                currentState.playerHealth -= 8*Time.deltaTime;
                if(currentState.playerHealth <= 10)
                {
                    SetState(GameOver);
                }
                
                //turn on spotlight
                //can be moved from here
                spotLightControl.enabled = currentState.spotLightEnabled;
                spotLightControl.range = currentState.playerHealth / 10f;

                //update timer
                timer += Time.deltaTime;

                //Player Movement


                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
                movementDirection.Normalize();

                playerControl.transform.Translate(movementDirection * 3 * Time.deltaTime, Space.World);

                if(movementDirection != Vector3.zero)
                {
                    playerControl.GetComponent<Animator>().SetBool("isWalk", true);

                    Quaternion setRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    playerControl.transform.rotation = Quaternion.RotateTowards(playerControl.transform.rotation, setRotation, 360 * Time.deltaTime);
                   

                }
                else
                {
                    playerControl.GetComponent<Animator>().SetBool("isWalk", false);
                }

                //move to pause state is esc is clicked
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SetState(Pause);
                }

                break;
            case 2:
                //Pause State

                camControl.transform.position = new Vector3(playerControl.transform.position.x - 2, 1, playerControl.transform.position.z - 1);
                camControl.transform.rotation = Quaternion.Euler(0, 35, 0);

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SetState(Play);
                }
                break;
            case 3:
                //Game Over State

                camControl.transform.position = new Vector3(playerControl.transform.position.x - 2, 1, playerControl.transform.position.z - 1);
                camControl.transform.rotation = Quaternion.Euler(0, 35, 0);

                playerControl.GetComponent<Animator>().SetBool("isWalk", false);


                camControl.GetComponent<AudioSource>().Stop();

                break;
            case 4:
                //Finish State
                camControl.transform.position = new Vector3(playerControl.transform.position.x - 2, 1, playerControl.transform.position.z - 1);
                camControl.transform.rotation = Quaternion.Euler(0, 35, 0);

                playerControl.GetComponent<Animator>().SetBool("isWalk", false);

                camControl.GetComponent<AudioSource>().Stop();

                finishFlag++;

                if (timer < highScore && finishFlag==1)
                {
                    highScore = timer;
                    foreach(GameObject uiGO in finishScreenElements)
                    {
                        if(uiGO.name == "HighScoreText")
                        {
                            uiGO.GetComponent<Text>().text = "HIGHSCORE!!!";
                        }
                        if(uiGO.name == "ScoreText")
                        {
                            uiGO.GetComponent<Text>().text = "Your Score:" + System.Math.Round(timer,2);
                        }
                    }
                }
                else if(finishFlag<2)
                {
                    foreach (GameObject uiGO in finishScreenElements)
                    {
                        if (uiGO.name == "HighScoreText")
                        {
                            uiGO.GetComponent<Text>().text = "WELL DONE!!!";
                        }
                        if (uiGO.name == "ScoreText")
                        {
                            uiGO.GetComponent<Text>().text = "Your Score:" + System.Math.Round(timer, 2) + "\nHigh Score:" + System.Math.Round(highScore, 2);
                        }
                    }
                }
                break;

            default:
                break;
        }
    }
}
