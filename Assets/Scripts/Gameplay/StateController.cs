﻿using UnityEngine;
using System.Collections;

public class StateController : MonoBehaviour, IMovementInput, IAttackInput
{
    [SerializeField] private State currentState;
    public State CurrentState { get { return currentState; } }

    public Vector2 InputVector
    {
        get
        {
            return inputVector;
        }
    }
    public bool AttackInput
    {
        get
        {
            return attackInput;
        }
    }


    [HideInInspector] public bool attackInput;
    [HideInInspector] public Vector2 inputVector = new Vector2();
    [HideInInspector] public Vector3 direction;

    [SerializeField] Transform[] waypoints;

    int currentWaypointIndex = 0;
    public int CurrentWaypointIndex
    {
        get { return currentWaypointIndex; }
        set
        {
            if (value != currentWaypointIndex)
            {
                if (value < 0)
                {
                    value = waypoints.Length - 1;
                }
                else if (value >= waypoints.Length)
                {
                    value = 0;
                }
                currentWaypointIndex = value;
            }
        }
    }
    public float distanceToTarget = 0.05f;
    public Vector3 TargetWaypointPosition
    {
        get
        {
            if (waypoints == null) return transform.position;
            if (waypoints.Length < 1) return transform.position;
            return waypoints[CurrentWaypointIndex].position;
        }
    }

    public float lookDistance = 10f;
    public float sphereCastRadius = 1f;
    [HideInInspector] public GameObject followObject;
    public Vector3 FollowObjectPosition
    {
        get
        {
            if (followObject == null) return transform.position;
            return followObject.transform.position;
        }
    }


    public float attackRange = 0.5f;


    void Update()
    {
        if (currentState == null) return;

        // reset inputs
        attackInput = false;
        inputVector = Vector2.zero;

        currentState.UpdateState(this);
    }

    // transition to next state
    public void TransitionToState(State targetState)
    {
        if (targetState == currentState) return;

        currentState = targetState;
    }
}
