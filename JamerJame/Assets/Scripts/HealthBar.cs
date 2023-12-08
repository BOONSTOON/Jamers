using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    [SerializeField] private float targetHealth;
    [SerializeField] private float curHealth;
    [SerializeField] private float vel;
    [SerializeField] public float damping = 0.5f;
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        targetHealth = health;
    }


    private void Update()
    {
        curHealth = Mathf.SmoothDamp(curHealth, targetHealth, ref vel, damping);
        slider.value = curHealth;
    }
    public void SetHealth(float health)
    {
        targetHealth = health;
    }
}
