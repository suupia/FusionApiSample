using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    [SerializeField] Ball _prefabBall;
    [Networked] TickTimer delay { get; set; }
    
    NetworkCharacterControllerPrototype _cc;
    Vector3 _forward;


    void Awake()
    {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize(); // チートを防ぐためにノーマライズされている
            _cc.Move(5*data.direction*Runner.DeltaTime);
        }

        if (data.direction.sqrMagnitude > 0) _forward = data.direction;
        
        if ((data.buttons & NetworkInputData.MOUSEBUTTON1) != 0)
        {
            delay = TickTimer.CreateFromSeconds(Runner, 0.5f);
            Runner.Spawn(
                _prefabBall,
                transform.position + _forward,
                Quaternion.LookRotation(_forward),
                Object.InputAuthority,
                (runner, o) =>
                {
                    // Initialize the Ball before synchronizing it 
                    o.GetComponent<Ball>().Init();
                }
            );
        }
    }
}
