using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text fullText;
    public Text startText;
    public int light1 = 0;
    public static GameManager instance;
    public GameObject lite;



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


    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {

        light1 = GameObject.Find("bottle").GetComponent<Bottle>().light;

        fullText.text = light1 + "% Full";

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("StarGame");
            startText.GetComponent<Text>().enabled = false;
        }

        if (light1 >= 100)
        {

            SceneManager.LoadScene("Level1");
        }


    }
}
