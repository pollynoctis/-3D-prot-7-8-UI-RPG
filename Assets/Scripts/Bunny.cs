using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bunny : Enemy
{
    private float healthGainChance;
    
    
    
    public override int Attack()
    {
        healthGainChance = Random.Range(0f, 1f);

        if (healthGainChance<0.2f)
        {
            health += 5;
        }
        return activeWeapon.GetDamage();
    }
    
}
