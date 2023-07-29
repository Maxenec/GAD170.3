using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ground;
    public float speedH = 30.0f;
    public float speedV = 30.0f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    public float rotationSpeed = 50f;
    private bool isDragging = false;
    private Vector3 lastMousePosition;
    public float zoomSpeed = 15f;
    public float minZoomDistance = 15f;
    public float maxZoomDistance = 50f;
    private float currentZoomDistance = 50f;

    private void Update()
    {
        // These lines let the script rotate the player based on the mouse moving

        if (Input.GetMouseButton(0))
        {
            yaw = speedH * Input.GetAxis("Mouse Y");
            pitch = speedV * Input.GetAxis("Mouse X");
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            DragCamera();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        zoomScroll();

    }

    void DragCamera()
    {
        float rotationAmount = rotationSpeed * pitch * Time.deltaTime;
        Vector3 axis = Vector3.up;
        transform.RotateAround(ground.position, axis, rotationAmount);
        lastMousePosition = Input.mousePosition;

    }

    void zoomScroll()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoomDistance -= zoomSpeed * scrollInput;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        Vector3 offset = transform.position - ground.position;
        offset = offset.normalized * currentZoomDistance;
        transform.position = ground.position + offset;
    }
}
