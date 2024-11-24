using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float starttime;
    public float speed = 10f;
    public float speed2 = 100f;
    private float time = 0;
    private float horizontal;
    public int force = 10;
    public GameObject lossGameScreen;
    public Rigidbody rb;
    private bool onCity;
    public bool onGame;

    void Start()
    {
        starttime = 0;
        onGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onGame)
        {
            starttime += Time.deltaTime;
            Debug.Log(starttime);

            horizontal = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up * Time.deltaTime * speed2 * horizontal);
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Space) && onCity)
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                onCity = false;
            }
            if (starttime >= 2)
            {
                speed += 1.5f;
                starttime = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("City"))
        {
            onCity = true;
        }
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Game Over");
            lossGameScreen.SetActive(true);
        }
    }
    public void StartGame()
    { 
        onGame = true;
    }

}
