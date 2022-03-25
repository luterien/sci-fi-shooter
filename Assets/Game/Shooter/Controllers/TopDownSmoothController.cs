using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownSmoothController : MonoBehaviour
{
    public LayerMask groundLayer;

    [Header("Components")]
    public Transform mainBody;
    public Animator animator;

    public float movespeed;
    public float deadZoneRange = 1f;
    public float turnSpeed;

    private Vector3 lookPoint;
    private Vector3 moveVector;

    private Vector3 cameraForward;
    private Vector3 cameraRight;

    public PlayerControls playerControls;

    private InputAction move;

    private Quaternion targetRotation;

    private void Awake()
    {
        cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;

        cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f;

        playerControls = PlayerControlsProvider.Get();

        move = playerControls.Player.Move;
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
        if (GameController.Paused) return;

        var v = move.ReadValue<Vector2>().y;
        var h = move.ReadValue<Vector2>().x;

        var hasMovement = (v != 0f || h != 0f);

        var screenPos = Camera.main.WorldToScreenPoint(mainBody.position);

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, groundLayer))
        {
            lookPoint = hitInfo.point;
            lookPoint.y = mainBody.position.y;

            var inDeadZone = Vector3.Distance(hitInfo.point, mainBody.position) <= deadZoneRange;

            SetLookAt(lookPoint - mainBody.position);

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
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetFloat("v", 0f);
                animator.SetFloat("h", 0f);
                animator.SetBool("Moving", false);
            }
        }
        else
        {
            mainBody.position += moveVector * movespeed * Time.deltaTime;

            animator.SetFloat("v", 0f);
            animator.SetFloat("h", 0f);
            animator.SetBool("Moving", false);
        }

        if (targetRotation != null)
        {
            mainBody.rotation = Quaternion.Lerp(mainBody.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }

    private void SetLookAt(Vector3 lookVector)
    {
        targetRotation = Quaternion.LookRotation(lookVector);
    }
}