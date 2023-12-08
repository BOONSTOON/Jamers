using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour, ICollectible
{
    [SerializeField] private float healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable<float> damageable = collision.gameObject.GetComponent<IDamageable<float>>();
        if (damageable != null)
        {
            damageable.Heal(healAmount);
            Collected();
        }
    }
    
    public void Collected()
    {
        Destroy(gameObject);
    }
}
