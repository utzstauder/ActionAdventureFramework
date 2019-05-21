using UnityEngine;
using System.Collections;

public class AttackBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 attackOffset = new Vector3(0, 0, 1f);
    [SerializeField] float attackSize = 1f;

    [SerializeField] DamageInfo damageInfo;

    Vector3 AttackPosition
    {
        get
        {
            return transform.position
            + transform.right * attackOffset.x
            + transform.up * attackOffset.y
            + transform.forward * attackOffset.z;
        }
    }

    public System.Action<DamageInfo> OnAttack;

    private IAttackInput attackInput;

    private void Awake()
    {
        attackInput = GetComponent<IAttackInput>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attackInput == null) return;

        if (attackInput.AttackInput)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (OnAttack != null)
        {
            OnAttack(damageInfo);
        }

        Collider[] colliders = Physics.OverlapSphere(AttackPosition, attackSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == gameObject) continue;

            IDamagable[] damagables = colliders[i].gameObject.GetComponentsInParent<IDamagable>();
            for (int j = 0; j < damagables.Length; j++)
            {
                damagables[j].DoDamage(damageInfo);
            }
       }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition, attackSize);
    }
}
