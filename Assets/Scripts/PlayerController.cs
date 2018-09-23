using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text pickUpText;
    public GameObject Player;

    private Rigidbody rb;
    private int score, pickUpCount;
    private Renderer re;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        pickUpCount = 0;
        SetAllText ();
        winText.text = "";
	}

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate ()
    {

        float colorR = Mathf.Abs(Player.transform.position.x / 10);
        float colorG = Mathf.Abs(Player.transform.position.y / 10);
        float colorB = Mathf.Abs(Player.transform.position.z / 10);
        Color colornow = new Vector4(colorR, colorG, colorB, 0.0f);
        Player.GetComponent<Renderer>().material.color = colornow;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            score = score + 1;
            SetAllText ();
        }

        if (other.gameObject.CompareTag("Bad Pick Up"))
        {
            other.gameObject.SetActive (false);
            score = score - 1;
            SetAllText();
        }
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            pickUpCount = pickUpCount + 1;
            SetAllText ();
        }
        if (pickUpCount == 12)
        {
            transform.position = new Vector3(0, -12, -1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy Blocker")
            score = score - 1;
        SetAllText();
    }

    void SetAllText ()
    {
        pickUpText.text = "Pick Ups Collectd: " + pickUpCount.ToString();

        countText.text = "Score: " + score.ToString ();
        if (pickUpCount == 24)
        {
            winText.text = "You won with a score of: " + score.ToString();
        }
    }
}
