using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; 
    public float damage = 20f; 
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Å¸°ÙÀ» ÇâÇØ ÀÌµ¿
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Å¸°Ù¿¡°Ô ÇÇÇØ¸¦ ÀÔÈû
        Enemy enemy = target.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject); // ÅºÈ¯ ÆÄ±«
    }
}