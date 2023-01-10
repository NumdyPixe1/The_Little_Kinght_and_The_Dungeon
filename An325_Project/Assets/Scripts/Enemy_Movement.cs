using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject[] wayPoints;
    private int currentWaypointIndex = 0;
    public float speedEnemy = 2f;

    void Update()
    {
        if (Vector2.Distance(wayPoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            transform.eulerAngles = new Vector2(0, 180);//หันไป 180 องศา
            currentWaypointIndex++;
            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
                transform.eulerAngles = new Vector2(0, 0);//หันไป 0 องศา
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime * speedEnemy);

    }























}
