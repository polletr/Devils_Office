using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerJoinManager : Singleton<PlayerJoinManager>
{
    PlayerInputManager inputManager;
    // Start is called before the first frame update
    void Awake()
    {
        inputManager = GetComponent<PlayerInputManager>();

    }

    public void JoinPlayer(int playerIndex)
    {
        inputManager.JoinPlayer(playerIndex, -1, "P" + playerIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
