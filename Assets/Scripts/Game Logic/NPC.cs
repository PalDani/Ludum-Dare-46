using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{

    [SerializeField] private LinkedList<Vector3> path = new LinkedList<Vector3>();
    public Vector3 CurrentPath { get { return path.First.Value; } }

    private NavMeshAgent agent;
    public Animator animator;
    public GameObject ClickDetector;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AddPath(GameObject.Find("Test Target path").transform.position);
        StartMoving();
        StartCoroutine(IgnoreObstacles());
    }

    
    void Update()
    {
        if (path.First.Value == transform.position)
        {
            path.RemoveFirst();
            agent.SetDestination(path.First.Value);
        }
    }

    public void AddPath(Vector3 target)
    {
        path.AddLast(target);
    }

    public void SetPath(Vector3 target)
    {
        agent.SetDestination(target);
    }

    public void StartMoving()
    {
        agent.isStopped = false;
        agent.SetDestination(path.First.Value);
    }

    public void StopMoving()
    {
        agent.isStopped = true;
    }

    public void ResetPath()
    {
        path.Clear();   
    }

    private IEnumerator IgnoreObstacles()
    {
        yield return new WaitForSeconds(4);
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
    }

    public void DisableAgent()
    {
        agent.enabled = false;
    }

    public void EnableAgent()
    {
        agent.enabled = true;
    }
}
