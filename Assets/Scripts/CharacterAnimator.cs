using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public float dampTime = .1f;
    
    private NavMeshAgent _agent;
    private Animator _animator;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        var speedPercent = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("speedPercent", speedPercent, dampTime, Time.deltaTime);
    }
}
