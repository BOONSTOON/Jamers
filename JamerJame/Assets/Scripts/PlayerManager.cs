using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable<float>
{
    // private members
    [SerializeField] private float curHealth;
    [SerializeField] private float maxHealth;

    // delegates
    public delegate void PlayerDying();
    public static PlayerDying playerDying;


    // references
    public HealthBar healthBar;



    // Start is called before the first frame update
    void Start()
    {
        // set health
        maxHealth = 100.0f;
        curHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        

    }

    private void Update()
    {
        if(curHealth <= 0)
        {
            playerDying?.Invoke();
        }
    }

    #region IDAMAGEABLE
    public void TakeDamage(float damageTaken)
    {
        
        curHealth -= damageTaken;
        if(curHealth < 0)
        {
            curHealth = 0;
        }
        healthBar.SetHealth(curHealth);
    }

    public void Heal(float damageHealed)
    {
        curHealth += damageHealed;
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        healthBar.SetHealth(curHealth);
    }
    #endregion IDAMAGEABLE


    public void Die()
    {
        curHealth = 0;
    }


    public void UpdateUI()
    {

    }



    public void OnEnable()
    {
        playerDying += Die;        
    }

    public void OnDisable()
    {
        playerDying -= Die;

    }
}
