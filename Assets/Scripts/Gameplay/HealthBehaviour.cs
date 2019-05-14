using UnityEngine;
using System.Collections;

public class HealthBehaviour : MonoBehaviour, IDamagable
{
    [SerializeField] int initialHp;

    int currentHp;
    int CurrentHp
    {
        get { return currentHp; }
        set
        {
            if (value != currentHp)
            {
                currentHp = value;
                if (currentHp <= 0)
                {
                    Die();
                }
            }
        }
    }

    public delegate void DeathAction();
    public DeathAction OnDeath;


    #region Unity Messages

    // Use this for initialization
    void Start()
    {
        CurrentHp = initialHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Private Functions

    void Die()
    {
        Debug.Log("Defeated");

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
        Debug.LogFormat("Received {0} {1} damage", info.amount, info.type.ToString());
        CurrentHp -= info.amount;
    }

    #endregion
}
