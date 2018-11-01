using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class Ennemy : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private float hitDistance;

    [Header("References")]
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform target;

    private float rotation = 0f;
    private float currentRotationVelocity;

    private void Update()
    {
        agent.SetDestination(target.position);

        bool running = agent.velocity != Vector3.zero;
        bool hit = (target.position - transform.position).magnitude < hitDistance;

        if (hit)
        {
            animator.SetTrigger("Hit");
        }

        animator.SetBool("Running", running);
    }
}
