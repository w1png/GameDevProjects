using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 5f;
    public float turnSpeed = 0.2f;
    public float fireRate = 1f;
    private float fireCountDownSeconds = 2f;

    [Header("Unity Setup Fields")]
    public Transform target;
    public string enemyTag = "Enemy";
    public Transform bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                nearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.LookAt(target);

        if (fireCountDownSeconds <= 0f)
        {
            Shoot();
            fireCountDownSeconds = 1f / fireRate;
        }

        fireCountDownSeconds -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).gameObject;
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, range);
    //}
}
