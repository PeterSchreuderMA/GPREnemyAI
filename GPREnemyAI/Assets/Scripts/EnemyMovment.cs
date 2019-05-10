using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public Transform enemeyTarget;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points 
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        //agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    public bool MoveToTarget(Vector3 _target, float _speed, float _maxDistanceBetween)
    {
        bool _return = false;

        agent.destination = _target;

        if (agent.remainingDistance < _maxDistanceBetween)
            _return = true;

        return _return;
    }


    void Update()
    {
        //if (!agent.pathPending)
        //    return;

        if (MoveToTarget(points[destPoint].position, 6f, 1))
            GotoNextPoint();
    }
}

