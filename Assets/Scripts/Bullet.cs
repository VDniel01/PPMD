using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    public bool isSlowBullet = false;
    public float slowAmount = 0.5f;
    public float slowDuration = 2f;

    public void SetTarget(Transform _target)
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

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        // Aplicar efectos al objetivo (por ejemplo, daño, ralentización)
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (isSlowBullet)
            {
                enemy.ApplySlow(slowAmount, slowDuration);
            }
        }

        Destroy(gameObject);
    }
}
