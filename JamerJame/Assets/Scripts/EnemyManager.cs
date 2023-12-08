using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDamageable<float>
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;
    [SerializeField] private float damage = 10.0f;

    #region IDAMAGEABLE
    public void TakeDamage(float damage)
    {

    }

    public void Heal(float damageHealed)
    {

    }
    #endregion IDAMAGEABLE

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // does collided object implement interface?
        IDamageable<float> damageable = collision.gameObject.GetComponent<IDamageable<float>>();
        if(damageable != null)
        {
            damageable.TakeDamage(10.0f);
        }
    }
}
