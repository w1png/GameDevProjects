using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float waitMoveTimeSeconds = 1f;

    private Transform target;
    private int waypointIndex = 0;

    private bool moveLock;

    void Start()
    {
        target = Waypoints.waypoints[waypointIndex];
    }

    IEnumerator MoveLikeChessPiece(Vector3 direction)
    {
        Vector3 targetPosition = transform.position + direction;


        moveLock = true;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            yield return null;
        }
        yield return new WaitForSeconds(waitMoveTimeSeconds);


        moveLock = false;
    }

        void Update()
    { 
        Vector3 direction = target.position - transform.position;
        if (!moveLock)
        {
            StartCoroutine(MoveLikeChessPiece(direction.normalized));
        }
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex < Waypoints.waypoints.Length - 1)
        {
            waypointIndex++;
            target = Waypoints.waypoints[waypointIndex];
            return;
        }

        Destroy(gameObject);
    }
}
