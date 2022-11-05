using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayer : MonoBehaviour
{
    Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            body.AddForce(new Vector2(0, 3),ForceMode2D.Force);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            body.velocity *= 0.4f;
        }
    }
}
