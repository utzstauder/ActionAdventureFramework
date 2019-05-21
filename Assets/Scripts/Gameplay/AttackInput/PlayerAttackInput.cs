using UnityEngine;
using System.Collections;

public class PlayerAttackInput : MonoBehaviour, IAttackInput
{
    private bool attackInput;
    public bool AttackInput { get { return attackInput; } }

    // Update is called once per frame
    void Update()
    {
        attackInput = Input.GetButtonDown("Jump");
    }
}
