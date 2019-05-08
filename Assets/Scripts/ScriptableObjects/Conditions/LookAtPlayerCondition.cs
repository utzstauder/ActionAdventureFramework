using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/Conditions/Look at Player Condition")]
public class LookAtPlayerCondition : Condition
{
    public override bool IsMet(StateController controller)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(
            controller.transform.position + controller.transform.forward,
            controller.transform.forward,
            out hitInfo,
            controller.lookDistance))
        {
            if (hitInfo.transform.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}
