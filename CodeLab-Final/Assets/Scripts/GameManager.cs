using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text fullText; //variable text object for how full the bottle is
    public Text startText; //variable text object that is enable and disable to cue player to press space to begin game
    public int light1; //variable integer that holds the light value for game manager
    public static GameManager instance; //this script is now accessible
    private bool complete; //boolean that makes it so i only reload level1 one time



    void Awake() //this is the singleton for the game object this script is attached to
    {
        if (instance == null)
        { //if theres no instance of this script
            instance = this; //now there is
            DontDestroyOnLoad(gameObject); //please dont destroy my game object
        }
        else
        {
            Destroy(gameObject); //otherwise if there is a duplicate, it is a fake, please destroy it on sight seargent
        }
    }


    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); //get the current scene
        light1 = 0; //light value in game manager starts at 0
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("StarGame")) //if we are playing the star game
        {
            light1 = GameObject.Find("bottle").GetComponent<Bottle>().light; //change the value of light1 by the value of light held in the bottle
        }

        fullText.text = light1 + "% Full"; //change the fulltext variable text object to include how much light has been caught

        if (Input.GetKeyDown("space")) //if the space bar has been pressed
        {
            SceneManager.LoadScene("StarGame"); //load the star game
            startText.GetComponent<Text>().enabled = false; //disable the startText text object so it doesnt load on the game
        }

        if (light1 >= 100 && complete == false) //if the value of light has reached 100 and this action has never been completed
        {

            SceneManager.LoadScene("Level1"); //reload level1
            complete = true; //this action has now been commpleted and wont be done again
        }


    }
}
