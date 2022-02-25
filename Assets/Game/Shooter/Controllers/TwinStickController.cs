using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickController : MonoBehaviour
{
    public Transform mainBody;
    public Animator animator;

    [Space]
    public float movespeed;
    public float turnSpeed;

    private Vector3 lookVector;
    private Vector3 moveVector;
    private Vector3 animationVector;

    private Vector3 cameraForward;
    private Vector3 cameraRight;

    private bool mouseDown = false;
    private bool hasMovement = false;

    private float v;
    private float h;

    private Quaternion targetRotation;

    private Timer timer;
    private float mouseUpTrackDuration = 0.5f;

    private bool mouseLingeringActive = false;

    private void Awake()
    {
        targetRotation = mainBody.rotation;

        cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;

        cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;

            timer = null;
            mouseLingeringActive = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            mouseLingeringActive = true;

            if (timer == null)
            {
                timer = new Timer(mouseUpTrackDuration);
                timer.Start();
            }
            else
            {
                timer.Restart();
            }
        }

        if (timer != null)
        {
            timer.Tick(Time.deltaTime);

            if (timer.Stopped)
            {
                timer = null;
                mouseLingeringActive = false;
            }
        }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        hasMovement = h != 0f || v != 0f;

        moveVector = (cameraForward * v + cameraRight * h).normalized;

        if (mouseDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
            {
                var lookPoint = hitInfo.point;
                lookVector = lookPoint - mainBody.position;
            }
        }
        else if (!mouseLingeringActive)
        {
            lookVector = moveVector;
        }

        if (targetRotation != null)
        {
            mainBody.rotation = Quaternion.Lerp(mainBody.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }

        animationVector = (moveVector - lookVector).normalized;

        SetMovementAndRotation();
        SetAnimationValues();
    }

    private void SetMovementAndRotation()
    {
        lookVector.y = 0f;

        mainBody.position += moveVector * Time.deltaTime * movespeed;

        if (lookVector != Vector3.zero && !mouseLingeringActive)
            SetLookAt(mainBody.position + lookVector);
    }

    private void SetLookAt(Vector3 point)
    {
        targetRotation = Quaternion.LookRotation(lookVector);
    }

    private void SetAnimationValues()
    {
        if (hasMovement && (mouseDown || mouseLingeringActive))
        {
            var moveVectorRight = Quaternion.Euler(0f, -90f, 0f) * moveVector;
            var dot = Vector3.Dot(moveVector.normalized, lookVector.normalized);
            var dot2 = Vector3.Dot(moveVectorRight.normalized, lookVector.normalized);

            animator.SetFloat("v", dot);
            animator.SetFloat("h", dot2);
            animator.SetInteger("test", 1);
        }
        else if (hasMovement && !mouseDown)
        {
            animator.SetFloat("v", 1f);
            animator.SetFloat("h", 0f);
            animator.SetInteger("test", 2);
        }
        else
        {
            animator.SetFloat("v", 0f);
            animator.SetFloat("h", 0f);
            animator.SetInteger("test", 3);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(mainBody.position, mainBody.position + lookVector);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(mainBody.position, mainBody.position + moveVector);
    }
}