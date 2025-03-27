using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get { return health;  }
        set { health = value; }
    }
    [SerializeField] internal Weapon activeWeapon;

    public Weapon ActiveWeapon
    {
        get { return activeWeapon; }
    }
    public virtual int Attack()
    {
        return activeWeapon.GetDamage();
    }

    public void GetHit(int damage)
    {
        health -= damage;
        //Debug.Log(name + "'s current health: " + health);
    }

    public void GetHit(Weapon weapon)
    {
        health -= weapon.GetDamage();
        /*Debug.Log(name + " got hit by " + weapon.name);
        Debug.Log(name + "'s current health: " + health);*/
    }
}
