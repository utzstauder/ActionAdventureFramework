using UnityEngine;
using System.Collections;

public class StateController : MonoBehaviour, IMovementInput
{
    [SerializeField] private State currentState;

    public Vector2 InputVector
    {
        get
        {
            return inputVector;
        }
    }

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
    public float lookDistance = 10f;

    public Vector3 TargetPosition
    {
        get
        {
            if (waypoints == null) return transform.position;
            if (waypoints.Length < 1) return transform.position;
            return waypoints[CurrentWaypointIndex].position;
        }
    }


    void Update()
    {
        if (currentState == null) return;

        currentState.UpdateState(this);
    }

    // transition to next state
    public void TransitionToState(State targetState)
    {
        if (targetState == currentState) return;

        currentState = targetState;
    }
}
