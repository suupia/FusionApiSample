using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    // ネットワークステートを更新するための、ホストが解釈する入力構造体

    public const byte MOUSEBUTTON1 = 0x01;
    public const byte MOUSEBUTTON2 = 0x02;

    public byte buttons;
    public Vector3 direction;
}
