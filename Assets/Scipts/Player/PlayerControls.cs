using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerControls : MonoBehaviour
{
    //Here lies our class fields
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float sprintSpeed = 2.0f;
    [SerializeField] private Gun myGun;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    //private InputManager inputManager;
    private Camera myCam;
    private GameObject parent;
    private InputActionAsset inputAsset;
    private InputActionMap player;


    // Start is called before the first frame update
    void Start()
    {   
        //Obtain components and references
        controller = GetComponent<CharacterController>();
        //inputManager = InputManager.Instance;
        parent = transform.parent.gameObject;
        myCam = parent.GetComponentInChildren<Camera>();


    }

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
    }

    private void OnEnable()
    {
        //Lock our cursor so that it isn't going all over the screen
        Cursor.lockState = CursorLockMode.Locked;
        //move = player.FindAction("Move");
        player.Enable();
        
    }

    private void OnDisable()
    {
        //Unlock it if we aren't using player (like menus etc.)
        Cursor.lockState = CursorLockMode.None;
        player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Set our grounded player variable based off character controller, then ensure y velocity isn't negative if we are on ground
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }

        //Create a vector3 that uses our input for movement, and orient it based off our camera
        Vector3 movement = GetCameraBasedInput(player.FindAction("Move").ReadValue<Vector2>(), myCam);
        //Create a vector3 using the values from movement except the vertical
        Vector3 move = new Vector3(movement.x, 0f, movement.z);
        //Move the character using the controller
        if (player.FindAction("Sprint").inProgress)
        {
            controller.Move(move * Time.deltaTime * playerSpeed * sprintSpeed);
        }
        else
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        //This rotates our character in the direction of our movement
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        //This controls our character jumping
        if (player.FindAction("Jump").triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        //This modifies our characters gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (player.FindAction("Reload").triggered)
        {
            myGun.Reload();
        }

        if (player.FindAction("Attack").triggered)
        {
            myGun.AttemptFire();
        }
    }
    //This function will take our input and modify it according to the direction our camera is facing
    Vector3 GetCameraBasedInput(Vector2 input, Camera cam)
    {
        Vector3 camRight = cam.transform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 camForward = cam.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        return input.x * camRight + input.y * camForward;
    }
}
