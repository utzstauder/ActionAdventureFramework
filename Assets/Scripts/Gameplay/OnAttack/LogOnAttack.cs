using UnityEngine;
using System.Collections;

public class LogOnAttack : OnAttackBase
{
    protected override void HandleOnAttack(DamageInfo damageType)
    {
        Debug.LogFormat("LogOnAttack | Type: {0} | Value: {1}",
            damageType.type, damageType.amount);
    }
}
