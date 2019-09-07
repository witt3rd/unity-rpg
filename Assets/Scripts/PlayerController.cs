using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    
    private Camera cam;

    private PlayerMotor motor;
    
    // Start is called before the first frame update
    void Start()
    {
    cam = Camera.main;
    motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        // Move on left click
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out var hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                // Defocus
            }
        }

        // Focus on right click
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out var hit, 100))
            {
                // Interactable?
            }
        }
    }
}
