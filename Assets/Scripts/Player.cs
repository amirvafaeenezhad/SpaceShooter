using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField] private float fireCan = 0;
    [SerializeField] private int lives = 3;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject TripleShotPrefab;
    [SerializeField] private bool isTripleShotActive;
    



    private void Start()
    {
        transform.position = new Vector3(1, 1, 1);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (spawnManager == null)
        {
            Debug.LogError("spawn manager is null");
        }
    }

    private void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > fireCan)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        fireCan = Time.time + fireRate;
        if (isTripleShotActive == true) 
        {
            Instantiate(TripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab , transform.position + new Vector3(0,.8f, 0), Quaternion.identity);
        }
           
    }

    public void Damage()
    {
        lives--;

        if (lives < 1)
        {
            spawnManager.OnPLayerDeath();
            Destroy(this.gameObject);
            
        } 
    }
    
    
    void CalculateMovement()
    {
        float horizontalOutput = Input.GetAxis("Horizontal");
        float verticalOutput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3 (horizontalOutput, verticalOutput, 0);

        Transform transform1 = transform;
        transform.Translate(  direction * speed * Time.deltaTime);
        if ( transform1.position.y >= 0)
        {
            transform1.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform1.position.y <= -3)
        {
            transform1.position = new Vector3(transform.position.x, -3, 0);
        }

        if (transform1.position.x > 9)
        {
            transform1.position = new Vector3(-9,transform.position.y, 0);
        }
        else if (transform1.position.x < -9)
        {
            transform1.position = new Vector3(9, transform.position.y, 0);
        }
    }
}
