using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _sppeed = 5;
    [SerializeField]
    private GameObject _LaserPrefab;
    [SerializeField]
    private float _fireRate = 0.3f;
    [SerializeField]
    private float _fireCan = 0;
    
    void Start()
    {
        transform.position = new Vector3(1, 1, 1);
    }

    void Update()
    {
        CalculatMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _fireCan)
        {
            Shoot();
        }
        
        
    }



    void Shoot()
    {
        Instantiate(_LaserPrefab , transform.position + new Vector3(0,.8f, 0), Quaternion.identity);
            _fireCan = Time.time + _fireRate;
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
