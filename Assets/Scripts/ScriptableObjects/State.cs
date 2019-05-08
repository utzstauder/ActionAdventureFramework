using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
    [SerializeField] Action[] actions;

    public void UpdateState(StateController controller)
    {
        // execute all actions
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].DoAction(controller);
        }
    }

    // TODO: transitions to other states
}
