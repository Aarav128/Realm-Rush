using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
    [SerializeField] float movementPerFrame = 0.1f;
    [SerializeField] float waypointDwellTime = 1f;

    private void Start() 
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();

        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            yield return StartCoroutine(MoveTowardsWaypoint(waypoint)); // wait until enemy moves to next waypoint
            yield return new WaitForSeconds(waypointDwellTime); // dwell on a waypoint for a little while
        }
    }

    private IEnumerator MoveTowardsWaypoint(Waypoint waypoint)
    {
        while (transform.position != waypoint.transform.position)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, waypoint.transform.position, movementPerFrame);
            transform.position = newPosition;

            yield return null; // wait until next frame
        }
    }
}