using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    private TextMesh textMesh;
    private Waypoint waypoint;

    private void Awake() 
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateName();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3
        (
            waypoint.GetGridPos().x * gridSize, 
            0,
            waypoint.GetGridPos().y * gridSize
        );
    }

    private void UpdateName()
    {
        string nameText = 
            waypoint.GetGridPos().x + 
            ", " +
            waypoint.GetGridPos().y;
        gameObject.name = nameText;
    }
}