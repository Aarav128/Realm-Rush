using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
    [SerializeField] float movementPerFrame = 0.1f;
    [SerializeField] float waypointDwellTime = 1f;
    [SerializeField] ParticleSystem goalParticle = null;

    private void Start() 
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();

        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        transform.position = path[0].transform.position;
        foreach (Waypoint waypoint in path)
        {
            yield return new WaitForSeconds(waypointDwellTime); // dwell on a waypoint for a little while
            yield return MoveTowardsWaypoint(waypoint); // wait until enemy moves to next waypoint
        }
        SelfDestruct();
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
    
    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject);
    }
}