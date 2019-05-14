using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/Conditions/In Attack Range Condition")]
public class InAttackRangeCondition : Condition
{
    public override bool IsMet(StateController controller)
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(
            controller.transform.position + controller.transform.forward,
            controller.sphereCastRadius,
            controller.transform.forward,
            out hitInfo,
            controller.attackRange))
        {
            if (hitInfo.transform.gameObject == controller.followObject)
            {
                return true;
            }
        }

        return false;
    }
}
