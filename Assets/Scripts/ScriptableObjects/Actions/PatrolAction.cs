using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/Actions/Patrol Action")]
public class PatrolAction : Action
{
    public override void DoAction(StateController controller)
    {
        if (ArrivedAtTargetPosition(controller))
        {
            // select next waypoint
            controller.CurrentWaypointIndex += 1;
            // CurrentWaypointIndex = Random.Range(0, waypoints.Length);
        }

        controller.direction = controller.TargetWaypointPosition - controller.transform.position;

        controller.inputVector.x = controller.direction.x;
        controller.inputVector.y = controller.direction.z;

        controller.inputVector.Normalize();
    }

    bool ArrivedAtTargetPosition(StateController controller)
    {
        return (Vector3.Distance(controller.transform.position, controller.TargetWaypointPosition) <= controller.distanceToTarget);
    }
}
