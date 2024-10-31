using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();

    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private List<LayerMask> playerLayers;

    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        playerInputManager = FindFirstObjectByType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        //Call this function when a player joins via the Player Input Manager component
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        //Disable function when component is disabled
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public int GetPlayers()
    {
        return players.Count;
    }

    public void AddPlayer(PlayerInput player)
    {
        //add this playerinput for our player object to the list of playerinputs
        players.Add(player);
        //obtain the parent of this object as the player has an empty parent with several children
        Transform playerParent = player.transform.parent;
        //Get the character controller of player and turn it off and back on in order to move via changing game objects position
        player.gameObject.GetComponent<CharacterController>().enabled = false;

        //Set our player to their corresponding spawn point
        playerParent.position = spawnPoints[players.Count - 1].position;
        player.gameObject.GetComponent<CharacterController>().enabled = true;

        //convert layer mask (bit) to an integer
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);


        //set the layer
        playerParent.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = layerToAdd;
        //get value of current player's layer so we can add it to our culling mask
        string playerCurrentLayer = LayerMask.LayerToName(layerToAdd);
        //add the layer
        playerParent.GetComponentInChildren<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig", "Player", "Environment", "Enemy", playerCurrentLayer);
        //set the player index in the cinemachine Input Handler
        playerParent.GetComponentInChildren<CinemachineInputProvider>().PlayerIndex = player.playerIndex;

    }
}
