using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 5.0f;
    private Rigidbody2D rigitBody;
    private Vector2 movement;

    void Start()
    {
        rigitBody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("SimplePlayer").transform;
    }

    void Update()
    {
        Vector3 dir = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rigitBody.rotation = angle;
        dir.Normalize();
        movement = dir;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rigitBody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
