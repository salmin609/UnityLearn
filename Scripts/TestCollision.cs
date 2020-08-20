using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision with {collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    void Start()
    {

    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Camera mainCamera = Camera.main;
        //    Vector3 mousePos = Input.mousePosition;
        //    Vector3 mousePosInWorld = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.nearClipPlane));
        //    Vector3 dir = mousePosInWorld - mainCamera.transform.position;
        //    dir = dir.normalized;

        //    Debug.DrawRay(mainCamera.transform.position, dir * 100.0f, Color.magenta, 1.0f);

        //    if (Physics.Raycast(mainCamera.transform.position, dir, out var hitInfo, 100.0f))
        //    {
        //        Debug.Log($"Raycast Cam {hitInfo.collider.gameObject.name}");
        //    }
        //}
    }
}
