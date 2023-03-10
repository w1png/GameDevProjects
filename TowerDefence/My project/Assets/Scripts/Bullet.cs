using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed;

    public float explosionRadius = 0f;

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
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
                transform.LookAt(target);
            }
            else 
                HitTarget();
            return;
        }
        Destroy(gameObject);
    }

    void HitTarget()
    {

        Destroy(Instantiate(hitParticles, target.position, target.rotation), 2f);

        if (explosionRadius > 0f)
        {
            Explode(target);
        } else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        // TODO: implement Damage and Explode coins
        PlayerManager.coins += 20;
        Destroy(enemy.gameObject);
    }

    void Explode(Transform enemy)
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in affectedObjects)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
                // TODO: line 53 comment
                PlayerManager.coins += 20;
            }
        }
    }
}
