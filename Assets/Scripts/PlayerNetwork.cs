using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<int> score = new NetworkVariable<int>(0);
    private NetworkVariable<int> playerId;
    private NetworkVariable<int> playerName;

}
