using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour, IProjectile
{
    public float speed;
    public float destroyAfter = 2f;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    public void Shoot(Vector3 direction)
    {
        velocity = direction * speed;

        transform.LookAt(transform.position + velocity);

        Destroy(gameObject, destroyAfter);
    }
}
