using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] bool placementRestricted = false;
    public bool PlacementRestricted {get {return placementRestricted;} }

    MeshRenderer tileMeshRenderer;
    Bank bank;
    
    void Start() 
    {
        tileMeshRenderer = GetComponentInChildren<MeshRenderer>();
        bank = FindObjectOfType<Bank>();
    }

    void OnMouseOver()
    {
        if (!placementRestricted)
        {
            setTileColour(1f, 3f, 1f); //sets tile colour to green
        }
        else
        {
            setTileColour(3f, 1f, 1f); //sets tile colour to red
        }
    }

    void OnMouseExit() 
    {
        setTileColour(1f,1f,1f); //resets tile colour to original colour
    }

    void OnMouseDown() 
    {
        if (!placementRestricted)
        {
            bool isPlaced = tower.CreateTower(tower, transform.position); // create the tower prefab
            placementRestricted = isPlaced;
        }
        else
        {
            Debug.Log("You cannot build here.");
        }
    }

    void setTileColour(float red, float green, float blue)
    {
        Color tileColour = new Color(red,green,blue);
        tileMeshRenderer.material.color = tileColour;
    }
}
