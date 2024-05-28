using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _sppeed = 5;
    [SerializeField]
    private GameObject _LaserPrefab;
    
    void Start()
    {
        transform.position = new Vector3(1, 1, 1);
    }

    void Update()
    {
        CalculatMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_LaserPrefab , transform.position, Quaternion.identity);
            //Debug.Log("created" );
        }
    }

    void CalculatMovement()
    {
        float horizontalOutput = Input.GetAxis("Horizontal");
        float verticalOutput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3 (horizontalOutput, verticalOutput, 0);
        
        transform.Translate(  direction * _sppeed * Time.deltaTime);
        if ( transform.position.y >= 0)
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
