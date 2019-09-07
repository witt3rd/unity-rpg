using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    
    private bool _isFocus = false;
    private Transform _player;
    private bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + _player.transform);
    }
    
    void Update()
    {
        if (_isFocus)
        {
            float distance = Vector3.Distance(_player.position, interactionTransform.position);
            if (distance <= radius && !hasInteracted)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        hasInteracted = false;
        _isFocus = true;
        _player = playerTransform;
    }

    public void OnDefocused()
    {
        hasInteracted = false;
        _isFocus = false;
        _player = null;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
