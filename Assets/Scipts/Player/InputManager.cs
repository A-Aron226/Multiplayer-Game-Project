using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private IA_Actions actions;

    private PlayerInputManager playerInputManager;

    private List<PlayerInput> players = new List<PlayerInput>();

    [SerializeField] private List<LayerMask> playerLayers;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        actions = new IA_Actions();
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void OnEnable()
    {
        actions.Enable();
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        actions.Disable();
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public Vector2 GetPlayerMovement()
    {
        return actions.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return actions.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        return actions.Player.Jump.triggered;
    }

    public void AddPlayer(PlayerInput player)
    {
        Transform playerParent = player.transform.parent;
        players.Add(player);

        //convert layer mask (bit) to an integer
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);

        //set the layer
        player.transform.parent.gameObject.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = layerToAdd;
        //add the layer
        playerParent.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;
        //set the action in the custom cinemachine Input Handler
        playerParent.GetComponentInChildren<InputHandler>().horizontal = player.actions.FindAction("Look");
    }
}
