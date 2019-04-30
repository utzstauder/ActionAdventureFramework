using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayAnimationOnAttack : OnAttackBase
{
    Animator animator;
    [SerializeField] string trigger;

    protected override void OnEnable()
    {
        base.OnEnable();
        animator = GetComponent<Animator>();
    }

    protected override void HandleOnAttack(DamageInfo obj)
    {
        if (animator != null)
        {
            animator.SetTrigger(trigger);
        }
    }

    public void ResetTrigger()
    {
        if (animator != null)
        {
            animator.ResetTrigger(trigger);
        }
    }
}
