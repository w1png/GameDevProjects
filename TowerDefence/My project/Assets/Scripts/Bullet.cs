using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed;

    public GameObject hitParticles;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) > 0.1f)
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
            else 
                HitTarget();
            return;
        }
        Destroy(gameObject);
    }

    void HitTarget()
    {
        Instantiate(hitParticles, target.position, target.rotation);
        Destroy(target.gameObject);
    }
}
