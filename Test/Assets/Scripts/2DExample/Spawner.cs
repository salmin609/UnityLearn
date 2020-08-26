using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject currObject;
    private float spawnTimer = 3.0f;
    public GameObject basicEnemy;
    public bool stopSpawning = false;
    public GameObject player;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    void Update()
    {
        if (player == null)
        {
            stopSpawning = true;
        }
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(basicEnemy, transform.position, Quaternion.identity);

        if (player != null)
        {
            enemy.GetComponent<PlayerChase>().playerTransform = player.transform;
        }

        if (stopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}
