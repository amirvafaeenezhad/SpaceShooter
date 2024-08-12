using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedUp = 8f;

    [SerializeField] private GameObject laserPrefab;

    void Start()
    {
        Debug.Log("created");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("the y position is: " + transform.position.y);

        transform.Translate(Vector3.up * speedUp * Time.deltaTime);
        if (transform.position.y > 7)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
            //Destroy(_LaserPrefab);
        }
    }
}