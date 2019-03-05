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

    // Use this for initialization
    void Start()
    {
        CurrentHp = initialHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Die()
    {
        Debug.Log("Defeated");
    }

    public void DoDamage(DamageInfo info)
    {
        CurrentHp -= info.amount;
    }
}
