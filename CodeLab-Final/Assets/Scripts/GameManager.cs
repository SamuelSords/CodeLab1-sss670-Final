using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text fullText;
    public int light1;
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        light1 = GameObject.Find("bottle").GetComponent<Bottle>().light;
    }

    // Update is called once per frame
    void Update()
    {
        light1 = GameObject.Find("bottle").GetComponent<Bottle>().light;

        fullText.text = light1 + "% Full";

        if (light1 >= 100)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
