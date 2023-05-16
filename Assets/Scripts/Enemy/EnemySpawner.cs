using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float randomEnemySpawnRange;
    public float respawnTime = 10f;
    Quaternion spawnRotation; // Add spawn rotation variable
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(RespawnCoroutine());
        spawnRotation = Quaternion.Euler(0 , 0 , 90);
    }

    IEnumerator RespawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Respawn();
        }
    }

    void Respawn()
    {
        GameObject enemyClone = Instantiate(enemyPrefab , transform.position , spawnRotation); // Modify Instantiate method
        enemyClone.transform.position = new Vector3(Random.Range(startPos.x - randomEnemySpawnRange , startPos.x + randomEnemySpawnRange) , startPos.y , startPos.z);
    }
}