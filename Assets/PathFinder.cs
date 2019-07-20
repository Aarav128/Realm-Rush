using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint = null;

    private void Start() 
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping and deleting Overlapping block " + waypoint);
                Destroy(waypoint.gameObject);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                ColorStartAndEnd(waypoint);
            }
        }
    }
    private void ColorStartAndEnd(Waypoint waypoint)
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
}
