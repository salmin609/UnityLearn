using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject currObject;
    void Start()
    {
        Managers.Input.MouseAction -= ClickToSpawn;
        Managers.Input.MouseAction += ClickToSpawn;
    }

    void Update()
    {
        
    }

    void ClickToSpawn(Define.MouseEvent mouseEvent)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Managers.Resource.Instantiate("2D/basic");
        }
    }
}
