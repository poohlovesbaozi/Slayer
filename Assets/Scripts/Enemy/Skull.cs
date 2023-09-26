using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Enemy
{
    protected override void Awake()
    {
        moveState = new SkullMoveState();
    }
}
