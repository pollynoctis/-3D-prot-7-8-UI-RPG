using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foxy : Enemy
{
    private float extraHitChance;
    
    public override int Attack()
    {
        extraHitChance = Random.Range(0f, 1f);
        if (extraHitChance<0.4f)
        {
            print("extra damage" );
            return activeWeapon.GetDamage() + 13;
        }
        return activeWeapon.GetDamage();
    }
}
