using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movment : MonoBehaviour
{
    //=== Criteria === 

    /*
     
     Move around[x]
     Rotate body[x]
     Implement extra movement options;
        Head Bobbing []
        Crouch []
        dash []
        Jump/ double jump [x] [x]
       
     */

    #region Player Movement Variables
    [Header("Player Movement Variables")]
    [SerializeField] private bool canMove;
    [SerializeField] private bool isMoving; // just to check if the player is geting inputs for movement
    [HideInInspector] private bool isOnGround = true;
    [SerializeField] private bool isCrouched;
    [SerializeField] private bool isSprintingEnabled = true;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [HideInInspector] public float maxVelocityChange = 10.0f;
    [SerializeField] public float jumpForceMultplyer = 5.0f;

    [HideInInspector] private int jumpCounter;
    [SerializeField] private const int MAX_JUMPS = 2;
    [HideInInspector] private const int JUMP_COOLDOWN = 180;
    #endregion

    #region Camera Variables
    [Header("Camera Variables")]
    [SerializeField] private bool canCameraMove;
    [HideInInspector] private bool isInverted = false;
    [HideInInspector] private bool isCursorVisible = false;

    [SerializeField] public float lookSensitivity;
    [HideInInspector] private float yaw = 0.0f;
    [HideInInspector] private float pitch = 0.0f;
    [SerializeField] private float clampAngle = 50.0f;
    [SerializeField] private float cameraOffsetY;


    #endregion

    #region flashlight Variables
    [SerializeField] private Light myLight;
    #endregion

    #region Player Input Keys
    [Header("Player Inputs")]
    [SerializeField] KeyCode sprintKey;
    [SerializeField] KeyCode toggleLightKey;
    [SerializeField] KeyCode jumpKey;

    #endregion

    #region other
    [Header("References")]
    [SerializeField] private GameObject myBodyRef;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Camera cam;
    #endregion

    private void Awake()
    {

    }

    void Start()
    {
        sprintSpeed = moveSpeed * 1.5f;
        playerRb = myBodyRef.gameObject.GetComponent<Rigidbody>();
        cam = Camera.main;
        isCursorVisible = false;
        myLight.enabled = false;

    }

    private void Update()
    {
        #region camera related
        CameraController();
        if (Input.GetKeyUp(toggleLightKey))
            toggleFlashLight();

        checkForCursorChange();
        #endregion

        if (Input.GetKeyUp(jumpKey))
            jump();

        if (Input.GetKeyUp(KeyCode.F1))
            SceneManager.LoadScene(0); // main menu
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (canMove)
        {
            // Calculate the speed the gameobject should move at
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // Checks if player is walking and isGrounded
            if (targetVelocity.x != 0 || targetVelocity.z != 0 && isOnGround)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }



            // All movement calculations shile sprint is active
            if (isSprintingEnabled && Input.GetKey(sprintKey))
            {
                targetVelocity = myBodyRef.transform.TransformDirection(targetVelocity) * sprintSpeed;

                // Apply a force that attempts to reach our target velocity
                Vector3 velocity = playerRb.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;

                // Player is only moving when valocity change != 0
                // Makes sure fov change only happens during movement
                if (velocityChange.x != 0 || velocityChange.z != 0)
                {
                    isSprintingEnabled = true;

                    if (isCrouched)
                    {
                        //Crouch();
                    }

                }

                playerRb.AddForce(velocityChange, ForceMode.VelocityChange);
            }
            // All movement calculations while walking
            else
            {

                //isSprintingEnabled = false;
                targetVelocity = myBodyRef.transform.TransformDirection(targetVelocity) * moveSpeed;

                //Apply a force that attempts to reach our target velocity
                Vector3 velocity = playerRb.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;

                playerRb.AddForce(velocityChange, ForceMode.VelocityChange);


            }

        }
    }

    private void CameraController()
    {
        if (canCameraMove)
        {
            Cursor.lockState = CursorLockMode.Confined;
            cam.transform.position = new Vector3(myBodyRef.transform.position.x, myBodyRef.transform.position.y + cameraOffsetY, myBodyRef.transform.position.z);
            yaw = myBodyRef.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * lookSensitivity;

            if (!isInverted)
            {
                pitch -= lookSensitivity * Input.GetAxis("Mouse Y");
            }
            else
            {
                // Inverted Y
                pitch += lookSensitivity * Input.GetAxis("Mouse Y");
            }

            // Clamp pitch between lookAngle
            pitch = Mathf.Clamp(pitch, -clampAngle, clampAngle);

            myBodyRef.transform.localEulerAngles = new Vector3(0, yaw, 0);
            cam.transform.localEulerAngles = new Vector3(pitch, 0, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void toggleFlashLight()
    {
        myLight.enabled = !myLight.enabled;
    }

    private void checkForCursorChange()
    {
        if (isCursorVisible)
        {
            changeCursorState(CursorLockMode.Confined);
        }
        else
        {
            changeCursorState(CursorLockMode.Locked);
        }
    }
    private void changeCursorState(CursorLockMode mode)
    {
        switch (mode)
        {
            case CursorLockMode.Confined:
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case CursorLockMode.Locked:
                Cursor.lockState = CursorLockMode.Locked;
                break;
            default:
                Debug.Log("Cursor Lock State is none");
                Cursor.lockState = CursorLockMode.None;
                break;
        }

    }

    private void jump()
    {
        if (jumpCounter < MAX_JUMPS)
        {
            jumpCounter++;
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForceMultplyer);
        }
        else
        {
            Debug.Log("Jump Limit reached");
            for (int i = 0; i <= JUMP_COOLDOWN; i++)
            {
                if (i == JUMP_COOLDOWN)
                    jumpCounter = 0;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isOnGround)
        {
            jumpCounter = 0;
            isOnGround = true;
        }
    }
}