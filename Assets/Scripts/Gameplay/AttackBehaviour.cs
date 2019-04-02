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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: extract this!
        if (Input.GetButtonDown("Jump"))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(AttackPosition, attackSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamagable damagable = colliders[i].gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.DoDamage(damageInfo);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition, attackSize);
    }
}
