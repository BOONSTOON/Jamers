using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable<T>
{
    void TakeDamage(T damageTaken);
    void Heal(T damageHealed);
}

public interface ICollectible
{
    void Collected();

}
