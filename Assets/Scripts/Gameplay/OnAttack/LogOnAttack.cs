using UnityEngine;
using System.Collections;

public class LogOnAttack : OnAttackBase
{
    private AudioSource audioSource;

    protected override void OnEnable()
    {
        base.OnEnable();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void HandleOnAttack(DamageInfo damageType)
    {
        Debug.LogFormat("LogOnAttack | Type: {0} | Value: {1}",
            damageType.type, damageType.amount);
    }
}
