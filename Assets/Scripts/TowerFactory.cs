using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab = null;
    [SerializeField] int towerLimit = 3;
    [SerializeField] Transform towerParent = null;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towerParent).GetComponent<Tower>();
        baseWaypoint.isPlaceable = false;
        tower.baseWaypoint = baseWaypoint;

        towerQueue.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();
        ChangeTowerWaypoint(newBaseWaypoint, oldTower);

        oldTower.transform.position = newBaseWaypoint.transform.position;
    }

    private void ChangeTowerWaypoint(Waypoint newBaseWaypoint, Tower tower)
    {
        tower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        tower.baseWaypoint = newBaseWaypoint;
        
        towerQueue.Enqueue(tower);
    }
}
