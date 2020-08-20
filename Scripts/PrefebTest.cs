using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefebTest : MonoBehaviour
{
    GameObject prefab;
    private GameObject obj;

    void Start()
    {
        obj = Managers.Resource.Instantiate("Tank");
        Managers.Resource.Destroy(obj, 3.0f);
    }
}
