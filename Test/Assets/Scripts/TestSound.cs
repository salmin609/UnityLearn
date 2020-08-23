using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool i = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!i)
        {
            Managers.Sound.Play("FreeSound/Cavern Atmosphere - Loop", Define.Sound.Bgm);
        }
        else
        {
            Managers.Sound.Play("FreeSound/Ghost Manifestation 2", type : Define.Sound.Bgm);
        }

        i = !i;
    }
}
