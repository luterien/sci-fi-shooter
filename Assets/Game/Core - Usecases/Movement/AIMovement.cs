using System.Collections;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform mainBody;
    public Transform target;

    public float Distance => Vector3.Distance(mainBody.position, target.position);
}