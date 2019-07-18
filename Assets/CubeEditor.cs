﻿using UnityEngine;

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
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3
        (
            waypoint.GetGridPos().x, 
            0,
            waypoint.GetGridPos().y
        );
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            waypoint.GetGridPos().x / gridSize + 
            ", " +
            waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}