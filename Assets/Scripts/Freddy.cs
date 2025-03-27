using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freddy : Enemy
{
    [SerializeField] private int agressionGain = 5;
    public override int Attack()
    {
        agression += agressionGain;
        return agression / 10;
    }
}
