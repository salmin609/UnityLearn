using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    private PlayerState currState = PlayerState.Idle;
    private Vector3 destPoisition = new Vector3(0.0f, 0.0f, 0.0f);

    //For first person controller
    private float translation;
    private float straffe;

    enum PlayerState
    {
        Idle,
        Die,
        Running
    }

    void Start()
    {
        Managers.Input.MouseAction -= MouseInput;
        Managers.Input.MouseAction += MouseInput;

        Managers.Input.KeyAction -= KeyboardMove;
        Managers.Input.KeyAction += KeyboardMove;

        Managers.Ui.ShowSceneUi<UiInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case PlayerState.Running:
                UpdateMoving();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    void UpdateMoving()
    {
        if (CameraController.camMode == Define.CamMode.QuarterView)
        {
            ClickToMove();
            RunAnimationControl();
        }
        else
        {

        }
    }

    void UpdateDie()
    {

    }
    void UpdateIdle()
    {
        IdleAnimationControl();
    }

    void KeyboardMove()
    {
        if (CameraController.camMode == Define.CamMode.PersonalView)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
                }

                currState = PlayerState.Running;
                RunAnimationControl();

                translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
                straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                transform.Translate(straffe, 0, translation);
            }
        }
    }

    void OnRunEvent()
    {
        Debug.Log("zz");
    }
    void ClickToMove()
    {
        if (currState == PlayerState.Running)
        {
            Vector3 dir = destPoisition - transform.position;
            if (dir.magnitude < 0.1f)
            {
                currState = PlayerState.Idle;
            }
            else
            {
                float moveDistance = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += (dir.normalized * moveDistance);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            }
        }
    }

    private void RunAnimationControl()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", speed);
    }

    private void IdleAnimationControl()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0.0f);
    }

    void MouseInput(Define.MouseEvent mouseEvent)
    {
        if (CameraController.camMode == Define.CamMode.QuarterView)
        {
            Camera mainCamera = Camera.main;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            int mask = 1 << 9;

            Debug.DrawRay(mainCamera.transform.position, ray.direction * 100.0f, Color.magenta, 1.0f);

            if (Physics.Raycast(ray, out var hitInfo, 100.0f, mask))
            {
                destPoisition = hitInfo.point;
                currState = PlayerState.Running;
            }
        }
    }
}
