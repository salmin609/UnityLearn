using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public static Define.CamMode camMode = Define.CamMode.QuarterView;
    [SerializeField]
    Vector3 distance;
    [SerializeField]
    GameObject player = null;
    [SerializeField] 
    Transform playerBody;


    public CameraController(Vector3 distance, GameObject player)
    {
        this.distance = distance;
        this.player = player;
    }

    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.KeyAction -= ChangeCamMode;
        Managers.Input.KeyAction += ChangeCamMode;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (camMode == Define.CamMode.QuarterView)
        {
            QuarterviewUpdate();
        }
        else
        {
            FirstPersonUpdate();
        }
    }

    void SetQuarterView(Vector3 distance)
    {
        camMode = Define.CamMode.QuarterView;
        this.distance = distance;
    }

    void QuarterviewUpdate()
    {
        if (Physics.Raycast(player.transform.position, distance, out var hitInfo, distance.magnitude,
            LayerMask.GetMask("Wall")))
        {
            float distance = (hitInfo.point - player.transform.position).magnitude * 0.8f;
            transform.position = (player.transform.position + this.distance.normalized * distance) + Vector3.up;
        }
        else
        {
            transform.position = player.transform.position + distance;
            transform.LookAt(player.transform);
        }
    }

    void FirstPersonUpdate()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * 100.0f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 100.0f * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
    }
    void ChangeCamMode()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (camMode == Define.CamMode.PersonalView)
            {
                transform.parent = null;
                camMode = Define.CamMode.QuarterView;
            }
            else
            {
                transform.parent = playerBody;
                transform.position = playerBody.position + new Vector3(0.0f, 2.0f, 0.0f);
                transform.rotation = Quaternion.identity;
                camMode = Define.CamMode.PersonalView;
            }
        }
    }
}
