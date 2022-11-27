using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JPlayer : MonoBehaviour
{
    Rigidbody2D body;
    public bool gameOver = false;
    public float VerticalSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Jetpack");
            }
        }

        if (Input.GetMouseButton(0))
        {
            body.AddForce(new Vector2(0, 1) * Time.deltaTime * VerticalSpeed,ForceMode2D.Force);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            body.velocity *= 0.4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver = true;
        body.isKinematic = true;
    }

}
