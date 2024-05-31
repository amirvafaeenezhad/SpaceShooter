using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy;

    [SerializeField] private float _speedDown = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 8 && transform.position.y > -8)
        {
            transform.Translate(Vector3.down * _speedDown * Time.deltaTime);
        }
        else
        {
            NewEnemy();
            Destroy(this.gameObject);
        }
            

    }
    
    private void NewEnemy()
    {
        int RandomX = Random.Range(-11, 11);
        Instantiate(_Enemy, new Vector3(RandomX, 7, transform.position.z), Quaternion.identity);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }    
}


    
