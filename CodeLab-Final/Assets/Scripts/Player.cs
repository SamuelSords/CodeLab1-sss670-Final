using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    Rigidbody2D rb;

    public Text startText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // move character
        transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, Input.GetAxis("Vertical") * 15f * Time.deltaTime, 0f);

        // flip character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -5;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 5;
        }
        transform.localScale = characterScale;

        if (transform.position.x > 1 && transform.position.x < 4 && transform.position.y > 2 && transform.position.y < 4)
        {
            startText.GetComponent<Text>().enabled = true;
        }
    }
}

