using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyScript))]
public class EnemyAnotherMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;

    private EnemyScript enemy;

    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        target = WaypointsTough.points[0];
    }

    void Update()
    {

        Vector3 dir = target.position - transform.position; //getting the vector of moving
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    void GetNextWayPoint()
    {
        if (wavepointIndex >= WaypointsTough.points.Length - 1)
        {
            EndPath();
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WaypointsTough.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
