using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnAttack : OnAttackBase
{
    AudioSource audioSource;

    protected override void OnEnable()
    {
        base.OnEnable();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void HandleOnAttack(DamageInfo obj)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
