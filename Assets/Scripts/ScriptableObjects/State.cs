using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
    [SerializeField] Action[] actions;
    [SerializeField] Transition[] transitions;

    public void UpdateState(StateController controller)
    {
        // execute all actions
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].DoAction(controller);
        }

        // check transition conditions
        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].condition.IsMet(controller))
            {
                // go to trueState
                controller.TransitionToState(transitions[i].trueState);
            } else
            {
                // go to falseState
                controller.TransitionToState(transitions[i].falseState);
            }

            if (controller.CurrentState != this)
            {
                // break out of transition loop
                // Debug.Log("Breaking out of transition loop");
                break;
            }
        }
    }
}
