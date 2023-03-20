using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    NetworkCharacterController _cc;

    void Awake()
    {
        _cc = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize(); // チートを防ぐためにノーマライズされている
            _cc.Move(5*data.direction*Runner.DeltaTime);
        }
    }
}
