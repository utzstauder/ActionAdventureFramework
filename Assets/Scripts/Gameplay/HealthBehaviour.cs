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
        Destroy(gameObject);
    }

    public void DoDamage(DamageInfo info)
    {
        Debug.LogFormat("Received {0} {1} damage", info.amount, info.type.ToString());
        CurrentHp -= info.amount;
    }
}
