using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
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
        Debug.Log(name + "'s current health: " + health);
    }

    public void GetHit(Weapon weapon)
    {
        health -= weapon.GetDamage();
        Debug.Log(name + " got hit my " + weapon.name);
        Debug.Log(name + "'s current health: " + health);
    }
}
