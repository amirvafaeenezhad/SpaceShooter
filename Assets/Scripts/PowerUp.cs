using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject tripleShotPowerUp;
    [SerializeField] private float speed=5;
    [SerializeField] private int powerUpID;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);

        if (transform.position.y<-4.5)
        {
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerUpID)
                {
                    case 0: player.TripleShotActive(); break;
                    case 1: player.speedBoosterActive(); break;
                    case 2: player.shieldBoosterActive(); break;
                    default:Debug.Log("Default Value"); break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
