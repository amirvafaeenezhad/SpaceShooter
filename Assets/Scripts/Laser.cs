using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _SpeedUp = 8f;

    [SerializeField] 
    private GameObject _LaserPrefab;

    void Start()
    {
        Debug.Log("created" );
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.up * _SpeedUp * Time.deltaTime);
        if (transform.position.y > 7)
        {
            Destroy(this.gameObject);
            //Destroy(_LaserPrefab);
        }
    }
}