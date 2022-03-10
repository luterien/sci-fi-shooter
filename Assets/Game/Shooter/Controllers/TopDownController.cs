using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour
{
    [Header("Components")]
    public Transform mainBody;
    public Animator animator;

    public float movespeed;

    private Vector3 lookPoint;
    private Vector3 moveVector;

    private Vector3 cameraForward;
    private Vector3 cameraRight;

    public PlayerControls playerControls;

    private InputAction move;
    private InputAction look;

    private void Awake()
    {
        cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;

        cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f;

        playerControls = new PlayerControls();

        move = playerControls.Player.Move;
        look = playerControls.Player.Look;
    }

    private void OnEnable()
    {
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        var v = move.ReadValue<Vector2>().y;
        var h = move.ReadValue<Vector2>().x;

        var hasMovement = (v != 0f || h != 0f);

        var screenPos = Camera.main.WorldToScreenPoint(mainBody.position);

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
        {
            lookPoint = hitInfo.point;
            lookPoint.y = mainBody.position.y;

            mainBody.LookAt(lookPoint);

            moveVector = hasMovement ? (v * cameraForward + cameraRight * h).normalized : Vector3.zero;

            mainBody.position += moveVector * movespeed * Time.deltaTime;

            if (hasMovement)
            {
                var lookVector = (lookPoint - mainBody.position).normalized;
                var moveVectorRight = Quaternion.Euler(0f, -90f, 0f) * moveVector;
                var dot = Vector3.Dot(moveVector.normalized, lookVector);
                var dot2 = Vector3.Dot(moveVectorRight.normalized, lookVector);

                animator.SetFloat("v", dot);
                animator.SetFloat("h", dot2);
            }
            else
            {
                animator.SetFloat("v", 0f);
                animator.SetFloat("h", 0f);
            }
        }
        else
        {
            mainBody.position += moveVector * movespeed * Time.deltaTime;

            animator.SetFloat("v", 0f);
            animator.SetFloat("h", 0f);
        }
    }
}