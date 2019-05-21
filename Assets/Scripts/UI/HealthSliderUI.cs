using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderUI : MonoBehaviour
{
    [SerializeField] HealthBehaviour healthBehaviour;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
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
        slider.normalizedValue = (float)arg1 / arg2;
    }
}
