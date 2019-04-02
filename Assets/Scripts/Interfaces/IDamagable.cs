using UnityEngine;
using System.Collections;

[System.Serializable]
public struct DamageInfo
{
    public enum DamageType
    {
        physical,
        fire,
        ice,
        poison,
        arcane
    }

    public int amount;
    public DamageType type;

    public DamageInfo(int amount, DamageType type)
    {
        this.amount = amount;
        this.type = type;
    }
}

public interface IDamagable
{
    void DoDamage(DamageInfo info);
    // System.Action OnDamageReceived { get; }
}
