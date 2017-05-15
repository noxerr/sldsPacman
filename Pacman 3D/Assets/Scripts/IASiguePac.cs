using UnityEngine;
using System.Collections;

public class IASiguePac : MonoBehaviour
{
    public Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.position;
    }
}
