using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColour;
    [SerializeField] Color restrictedColour = Color.grey;
    
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        waypoint = GetComponentInParent<Waypoint>();
        defaultColour = label.color;
        label.enabled = false;
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            label.enabled = true;
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColour(); // changes coordinate colours depending on placeability
        ToggleLabels(); // toggle visibility of labels on and off
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + ", " + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void SetLabelColour()
    {
        if (!waypoint.PlacementRestricted)
        {
            label.color = defaultColour; // if the tile is not placement restricted, use default colours
        }
        else
        {
            label.color = restrictedColour; // if the tile is placement restricted, use the restricted colour
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }
}
