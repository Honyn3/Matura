using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCamera : MonoBehaviour
{
    public JPlayer player;
    public float HorizontalSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        HorizontalSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameOver)
        {
            transform.position += new Vector3(HorizontalSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void StartSpeed()
    {
        HorizontalSpeed = 5;
    }
}
