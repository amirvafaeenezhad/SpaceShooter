using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class TripleShot : MonoBehaviour
{
    [SerializeField] private GameObject tripleShotPowerUp;
    [SerializeField] private float Speed=5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(Random.Range(-11, 11), 7, 1);
        Instantiate(tripleShotPowerUp, transform.position, Quaternion.identity);
            
        while(-4< transform.position.y && transform.position.y<7)
        {
            transform.Translate(Vector3.down*Speed*Time.deltaTime);
        }
        Destroy(this.GameObject());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
