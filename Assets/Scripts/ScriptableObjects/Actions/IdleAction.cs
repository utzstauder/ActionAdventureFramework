using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/Actions/Idle Action")]
public class IdleAction : Action
{
    public override void DoAction(StateController controller)
    {
        controller.inputVector = Vector2.zero;
    }
}
