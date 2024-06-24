using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private bool stopSpawn = false;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
    {
        while (stopSpawn == false)
        {
            Vector3 PosToSpawn = new Vector3(Random.Range(-8, 8), 7, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, PosToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }
        
    }

    
    public void OnPLayerDeath()
    {
        stopSpawn = true;
    }
    
}
