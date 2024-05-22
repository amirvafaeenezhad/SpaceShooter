using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sppeed = 1;
    void Start()
    {
        transform.position = new Vector3(1, 1, 1);
        
    }

    void Update()
    {
        CalculatMovement();
    }

    void CalculatMovement();
    {
        float horizontalOutput = Input.GetAxis("Horizontal");
        float verticalOutput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3 (horizontalOutput, verticalOutput, 0);
        
        transform.Translate(  direction * sppeed * Time.deltaTime);
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3)
        {
            transform.position = new Vector3(transform.position.x, -3, 0);
        }

        if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9,transform.position.y, 0);
        }
        else if (transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
    }
}
