using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();

    [SerializeField] private List<LayerMask> playerLayers;

    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        playerInputManager = FindFirstObjectByType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        //add this playerinput for our player object to the list of playerinputs
        players.Add(player);
        //obtain the parent of this object as the player has an empty parent with several children
        Transform playerParent = player.transform.parent;

        //convert layer mask (bit) to an integer
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);


        //set the layer
        playerParent.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = layerToAdd;
        //get value of current player's layer so we can add it to our culling mask
        string playerCurrentLayer = LayerMask.LayerToName(layerToAdd);
        //add the layer
        playerParent.GetComponentInChildren<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig", playerCurrentLayer);
        //set the player index in the cinemachine Input Handler
        playerParent.GetComponentInChildren<CinemachineInputProvider>().PlayerIndex = player.playerIndex;

    }
}
