using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPointIndex = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, wayPoints[currentWayPointIndex].transform.position) < .1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
