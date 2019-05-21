using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthTextUI : MonoBehaviour
{
    Text textComponent;

    [SerializeField] HealthBehaviour healthBehaviour;
    [SerializeField] string separatorString = "/";

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    private void OnEnable()
    {
        if (healthBehaviour != null)
        {
            // subscribe to event
            healthBehaviour.OnHpChanged -= HealthBehaviour_OnHpChanged;
            healthBehaviour.OnHpChanged += HealthBehaviour_OnHpChanged;
        }
    }

    private void OnDisable()
    {
        if (healthBehaviour != null)
        {
            // unsubscribe from event
            healthBehaviour.OnHpChanged -= HealthBehaviour_OnHpChanged;
        }
    }

    private void HealthBehaviour_OnHpChanged(int arg1, int arg2)
    {
        // Debug.Log("OnHpChanged event received.");
        textComponent.text = arg1 + separatorString + arg2;

    }
}
