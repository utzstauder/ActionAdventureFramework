using UnityEngine;
using System.Collections;

public class HealthBehaviour : MonoBehaviour, IDamagable
{
    [SerializeField] int initialHp;

    public int MaxHp { get { return initialHp; } }

    int currentHp;
    public int CurrentHp
    {
        get { return currentHp; }
        private set
        {
            if (value != currentHp)
            {
                currentHp = value;

                if (OnHpChanged != null)
                {
                    OnHpChanged(currentHp, MaxHp);
                }

                if (currentHp <= 0)
                {
                    Die();
                }
            }
        }
    }

    public delegate void DeathAction();
    public DeathAction OnDeath;

    public event System.Action<int, int> OnHpChanged;


    #region Unity Messages

    // Use this for initialization
    void Start()
    {
        CurrentHp = initialHp;
    }

    #endregion


    #region Private Functions

    void Die()
    {
        // Debug.Log("Defeated");

        if (OnDeath != null)
        {
            OnDeath.Invoke();
        }

        // Destroy(gameObject);
    }

    #endregion

    #region Interface Functions

    public void DoDamage(DamageInfo info)
    {
        // Debug.LogFormat("Received {0} {1} damage", info.amount, info.type.ToString());
        if (CurrentHp > 0)
        {
            CurrentHp -= info.amount;
        }
    }

    #endregion
}
