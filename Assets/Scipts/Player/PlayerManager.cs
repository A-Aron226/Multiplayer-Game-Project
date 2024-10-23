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
        players.Add(player);

        Transform playerParent = player.transform.parent;

        //convert layer mask (bit) to an integer
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);

        //set the layer
        playerParent.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = layerToAdd;
        //add the layer
        Debug.Log(playerParent.GetComponentInChildren<Camera>().cullingMask);
        playerParent.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;
        Debug.Log(playerParent.GetComponentInChildren<Camera>().cullingMask);
        //set the action in the custom cinemachine Input Handler
        Debug.Log(player.playerIndex);
        playerParent.GetComponentInChildren<CinemachineInputProvider>().PlayerIndex = player.playerIndex;
        //playerParent.GetComponentInChildren<InputHandler>().horizontal = player.actions.FindAction("Look");
    }
}
