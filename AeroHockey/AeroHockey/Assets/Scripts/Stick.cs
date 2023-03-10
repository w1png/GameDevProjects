using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField]
    private Collider planeCollider;
    [SerializeField]
    private Rigidbody rigidBody;

    public float force = 2f;

    private void FixedUpdate()
    {
        rigidBody.velocity = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (planeCollider.Raycast(ray, out RaycastHit hit, 100f))
        {
            Vector3 distance = hit.point - rigidBody.position;

            if (rigidBody.position.x < 1.3f)
            {
                distance.x = 3f;
                rigidBody.MovePosition(distance);
                return;
            }


            rigidBody.AddForce(distance.normalized * force);
        }
    }

}
