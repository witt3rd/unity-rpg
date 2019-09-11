using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    
    private bool _isFocus = false;
    private Transform _player;
    private bool _hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + _player.transform);
    }
    
    void Update()
    {
        if (_isFocus)
        {
            float distance = Vector3.Distance(_player.position, interactionTransform.position);
            if (distance <= radius && !_hasInteracted)
            {
                _hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        _hasInteracted = false;
        _isFocus = true;
        _player = playerTransform;
    }

    public void OnDefocused()
    {
        _hasInteracted = false;
        _isFocus = false;
        _player = null;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
                
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
