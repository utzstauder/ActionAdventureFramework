using UnityEngine;
using System.Collections;
using System;

public abstract class OnAttackBase : MonoBehaviour
{

    protected virtual void OnEnable()
    {
        // subscribe to OnAttack
        AttackBehaviour attackBehaviour = GetComponent<AttackBehaviour>();

        if (attackBehaviour != null)
        {
            attackBehaviour.OnAttack -= HandleOnAttack;
            attackBehaviour.OnAttack += HandleOnAttack;
        }
    }

    protected virtual void OnDisable()
    {
        // unsubscribe from OnAttack
        AttackBehaviour attackBehaviour = GetComponent<AttackBehaviour>();

        if (attackBehaviour != null)
        {
            attackBehaviour.OnAttack -= HandleOnAttack;
        }
    }

    protected virtual void HandleOnAttack(DamageInfo obj)
    {
        throw new NotImplementedException();
    }
}
