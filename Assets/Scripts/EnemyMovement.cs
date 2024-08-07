using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    private Transform target;
    private int waypointIndex = 0;
    private float originalSpeed;

    void Start()
    {
        target = Waypoints.points[0];
        originalSpeed = speed;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void ApplySlow(float slowAmount, float duration)
    {
        speed = originalSpeed * (1f - slowAmount);
        Invoke("ResetSpeed", duration);
    }

    void ResetSpeed()
    {
        speed = originalSpeed;
    }
}
