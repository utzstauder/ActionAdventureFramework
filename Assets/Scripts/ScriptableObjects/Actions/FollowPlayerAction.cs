using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/Actions/Follow Player Action")]
public class FollowPlayerAction : Action
{
    public override void DoAction(StateController controller)
    {
        controller.direction = controller.FollowObjectPosition - controller.transform.position;

        controller.inputVector.x = controller.direction.x;
        controller.inputVector.y = controller.direction.z;

        controller.inputVector.Normalize();
    }
}
