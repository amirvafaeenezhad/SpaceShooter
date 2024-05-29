using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speedDown = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <7 && transform.position.y>-7 )
        {
            transform.Translate(Vector3.down* _speedDown* Time.deltaTime);
        }
        else
        {
            int RandomX = Random.Range(-11, 11);
            Instantiate(RandomX, 7, Quaternion.identity);
        }
        
    }
}
