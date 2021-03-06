﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/Conditions/Look at Player Condition")]
public class LookAtPlayerCondition : Condition
{
    public override bool IsMet(StateController controller)
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(
            controller.transform.position + controller.transform.forward,
            controller.sphereCastRadius,
            controller.transform.forward,
            out hitInfo,
            controller.lookDistance))
        {
            if (hitInfo.transform.gameObject.CompareTag("Player"))
            {
                controller.followObject = hitInfo.transform.gameObject;
                return true;
            }
        }

        controller.followObject = null;
        return false;
    }
}
