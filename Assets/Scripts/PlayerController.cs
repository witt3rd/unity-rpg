using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    private Camera _cam;

    private PlayerMotor _motor;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = _cam.ScreenPointToRay(Input.mousePosition);

        // Move on left click
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out var hit, 100, movementMask))
            {
                _motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        // Focus on right click
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out var hit, 100))
            {
                var obj = hit.collider.GetComponent<Interactable>();
                if (obj != null)
                {
                    SetFocus(obj);
                }
            }
        }
    }

    public Interactable focus;

    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            _motor.FollowTarget(focus);
        }

        focus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        _motor.StopFollowingTarget();
    }
}