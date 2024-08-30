using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Camera dragCamera; // Reference to the camera to use for dragging
    private Vector3 offset;
    private float zCoordinate;

    void Start()
    {
        // If no camera is specified, default to the main camera
        if (dragCamera == null)
        {
            dragCamera = Camera.main;
        }
    }

    void OnMouseDown()
    {
        if (GameManager.gameMode == 2)
        {
            // Capture the object's z-coordinate when the mouse is pressed
            zCoordinate = dragCamera.WorldToScreenPoint(gameObject.transform.position).z;

            // Capture the offset between the mouse position and the object position
            offset = gameObject.transform.position - GetMouseWorldPosition();
        }
    }

    void OnMouseDrag()
    {
        if (GameManager.gameMode == 2)
        {
            // Update the object's position as the mouse is dragged
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the current mouse position on screen
        Vector3 mousePoint = Input.mousePosition;

        // Set the z-coordinate to the one captured during OnMouseDown
        mousePoint.z = zCoordinate;

        // Convert screen position to world position using the specified camera
        return dragCamera.ScreenToWorldPoint(mousePoint);
    }
}

