using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PhysxBall : NetworkBehaviour
{
    [Networked] TickTimer life { get; set; }

    public void Init(Vector3 forward)
    {
        life = TickTimer.CreateFromSeconds(Runner, 5.0f);
        GetComponent<Rigidbody>().velocity = forward;
    }

    public void FixedUpdateNetwork()
    {
        if (life.Expired(Runner))
        {
            Runner.Despawn(Object);
        }
    }
}
