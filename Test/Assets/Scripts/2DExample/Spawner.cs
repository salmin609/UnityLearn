using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject currObject;
    private float spawnTimer = 3.0f;

    void Start()
    {
    }

    void Update()
    {
        if (spawnTimer > 0.0f)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            Managers.Resource.Instantiate("2D/Basic");
            spawnTimer = 3.0f;
        }
    }
}
