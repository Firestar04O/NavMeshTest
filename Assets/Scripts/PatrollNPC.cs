using UnityEngine;
using UnityEngine.AI;

public class PatrollNPC : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] public Transform[] patrolPoints;
    private int currentIndex = 0;
    private float remainingDistance;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        if(patrolPoints.Length > 0)
        {
            MoveToNextPoint();
        }
    }
    private void Update()
    {
        remainingDistance = Vector3.Distance(transform.position, patrolPoints[currentIndex].position);
        if (remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }
    private void MoveToNextPoint()
    {
        if(patrolPoints.Length == 0)
        {
            return;
        }
        currentIndex = (currentIndex + 1) % patrolPoints.Length;
        MoveTo(patrolPoints[currentIndex].position);
    }
    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
