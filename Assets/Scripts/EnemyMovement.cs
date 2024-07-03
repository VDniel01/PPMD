using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    private Queue<Transform> waypointsQueue;
    private Transform target;

    void Start()
    {
        // Cargar los waypoints en una cola
        waypointsQueue = new Queue<Transform>(Waypoints.points);

        // Establecer el primer waypoint como objetivo
        if (waypointsQueue.Count > 0)
        {
            target = waypointsQueue.Dequeue();
        }
        else
        {
            Debug.LogError("No waypoints found!");
        }

        // Iniciar la corrutina de movimiento
        StartCoroutine(MoveToNextWaypoint());
    }

    IEnumerator MoveToNextWaypoint()
    {
        while (true)
        {
            if (target != null)
            {
                Vector3 direction = target.position - transform.position;
                transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, target.position) <= 0.2f)
                {
                    GetNextWaypoint();
                }
            }
            yield return null;
        }
    }

    void GetNextWaypoint()
    {
        if (waypointsQueue.Count > 0)
        {
            target = waypointsQueue.Dequeue();
        }
        else
        {
            Debug.Log("Reached the last waypoint. Destroying enemy.");
            Destroy(gameObject);
        }
    }
}
