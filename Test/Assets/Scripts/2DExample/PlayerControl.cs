using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float dashSpeed = 100.0f;
    public float dashTime = 0.3f;
    private float startDashTime = 0.3f;
    private Vector2 direction;

    private Rigidbody2D rigidBody;
    private Transform transform;

    private Vector2 prevPos;
    private Vector2 currPos;
    private bool dashStarted = false;

    public GameObject dashEffect;
    public GameObject enemyKillEffect;

    private ParticleSystem particle;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        CheckKeyDown();
        CheckDash();
    }

    void CheckKeyDown()
    {
        prevPos = transform.position;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        currPos = transform.position;
    }

    void CheckDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = currPos - prevPos;
            rigidBody.velocity = Util.VectorInterpolationOneToMinusOne(direction) * dashSpeed;
            startDashTime = dashTime;
            dashStarted = true;
            GameObject obj = Instantiate(dashEffect, transform.position, Quaternion.identity);
            Destroy(obj, 1.0f);

            Camera mainCam = Camera.main;
            Animator mainCamSahke = mainCam.GetComponent<Animator>();
            mainCamSahke.enabled = true;
        }

        if (dashStarted == true)
        {
            if (startDashTime > 0.0f)
            {
                startDashTime -= Time.deltaTime;
            }
            else
            {
                rigidBody.velocity = Vector2.zero;
                startDashTime = 0.0f;
                dashStarted = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (dashStarted)
            {
                GameObject killParticle = Instantiate(enemyKillEffect, collision.transform.position, Quaternion.identity);
                Managers.Resource.Destroy(collision.gameObject);
                Object.Destroy(killParticle, 1.0f);
            }
            else
            {
                Debug.Log("Dead");
            }
        }
    }
}


