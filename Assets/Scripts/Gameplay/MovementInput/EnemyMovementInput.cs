using UnityEngine;
using System.Collections;

public class EnemyMovementInput : MonoBehaviour, IMovementInput
{
    public Vector2 InputVector
    {
        get
        {
            return inputVector;
        }
    }

    Vector2 inputVector = new Vector2();
    Vector3 direction;

    [SerializeField] Transform[] waypoints;

    int currentWaypointIndex = 0;
    int CurrentWaypointIndex
    {
        get { return currentWaypointIndex; }
        set
        {
            if (value != currentWaypointIndex)
            {
                if (value < 0)
                {
                    value = waypoints.Length - 1;
                } else if (value >= waypoints.Length)
                {
                    value = 0;
                }
                currentWaypointIndex = value;
            }
        }
    }

    [SerializeField] float distanceToTarget = 0.05f;

    Vector3 TargetPosition {
        get {
            if (waypoints == null) return transform.position;
            if (waypoints.Length < 1) return transform.position;
            return waypoints[CurrentWaypointIndex].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ArrivedAtTargetPosition())
        {
            // select next waypoint
            CurrentWaypointIndex += 1;
            // CurrentWaypointIndex = Random.Range(0, waypoints.Length);
        }

        direction = TargetPosition - transform.position;

        inputVector.x = direction.x;
        inputVector.y = direction.z;

        inputVector.Normalize();
    }

    bool ArrivedAtTargetPosition()
    {
        return (Vector3.Distance(transform.position, TargetPosition) <= distanceToTarget);
    }
}
