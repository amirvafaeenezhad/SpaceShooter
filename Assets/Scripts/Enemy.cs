using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speedDown = 4f;
    Player player;

     void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (transform.position.y < 8 && transform.position.y > -8)                                     
        {
            transform.Translate(Vector3.down * speedDown * Time.deltaTime);             
        }
        else
        {
           // NewEnemy();
            Destroy(this.gameObject);
        }
    }

    //private void NewEnemy()
   //{
       // int randomX = Random.Range(-9, 9);
     //   Instantiate(enemy, new Vector3(randomX, 7, transform.position.z), Quaternion.identity);
   // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit:" + other.transform.name);
        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if (player != null)
            {
             player.AddScore(10);   
            }
            Destroy(this.gameObject);
            
        }
    }
}