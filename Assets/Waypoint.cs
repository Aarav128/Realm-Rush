using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;

    private const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int
        (
            Mathf.RoundToInt(transform.position.x / gridSize) * 10,
            Mathf.RoundToInt(transform.position.z / gridSize) * 10   
        );
    }
}
