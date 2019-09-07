using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    
    public float pitch = 2f;
    public float yawSpeed = 100f;
        
    private float _currentZoom = 10f;
    private float _currentYaw = 0f;
    
    private void Update()
    {
        _currentZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        _currentZoom = Mathf.Clamp(_currentZoom, minZoom, maxZoom);

        _currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        var position = target.position;
        transform.position = position - offset * _currentZoom;
        transform.LookAt(position + Vector3.up * pitch);
        transform.RotateAround(position, Vector3.up, _currentYaw);
    }
}
