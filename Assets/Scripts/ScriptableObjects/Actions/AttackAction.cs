using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/Actions/Attack Action")]
public class AttackAction : Action
{
    public override void DoAction(StateController controller)
    {
        controller.attackInput = true;
    }
}
