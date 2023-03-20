using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    // ネットワークステートを更新するための、ホストが解釈する入力構造体
    public Vector3 direction;
}
