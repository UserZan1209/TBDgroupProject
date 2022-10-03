using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    //=== Criteria === 

    /*
     
     Move around and be restricted by barriers to maintain a 2D look []

     Rotate body to face the direction of movement []

     Implement extra movement options;
        Crouch []
        Roll []
        Jump []
        Swing []

     */

    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private GameObject myBodyRef;

    [HideInInspector] private enum myDirections { Left, Right, Up, Down };
    [SerializeField] private myDirections playerDirection = myDirections.Right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        setPlayerRotation();
    }

    private void movePlayer(float xInput, float yInput)
    {
        transform.Translate(xInput * Time.deltaTime * moveSpeed, 0.0f, yInput * Time.deltaTime * moveSpeed);
    }

    private void setPlayerDirection(float xInput, float yInput)
    {
        //Debug.Log("RAW Xinput: " + xInput + "RAW Yinput: " + yInput);

        if(yInput == 0.0f)
        {
            if (xInput > 0)
            {
                playerDirection = myDirections.Right;
            }
            else if (xInput < 0)
            {
                playerDirection = myDirections.Left;
            }
            else
            {
                Debug.Log("X = Zero");
            }
        }
        else
        {
            if(yInput > 0)
            {
                playerDirection = myDirections.Up;
            }
            else if(yInput < 0)
            {
                playerDirection = myDirections.Down;
            }
        }

    }

    private void setPlayerRotation()
    {
        setPlayerDirection(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Quaternion rot = new Quaternion(0, 0, 0, 1);
        switch (playerDirection) 
        {
            case myDirections.Right:
                rot = new Quaternion(0,180,0,1);
                myBodyRef.transform.SetPositionAndRotation(transform.position, rot);
                break;
            case myDirections.Left:
                rot = new Quaternion(0, 0, 0, 1);
                myBodyRef.transform.SetPositionAndRotation(transform.position, rot);
                break;
            case myDirections.Up:
                rot = new Quaternion(0, 90, 0, 1);
                myBodyRef.transform.SetPositionAndRotation(transform.position, rot);
                break;
            case myDirections.Down:
                rot = new Quaternion(0, 270, 0, 1);
                myBodyRef.transform.SetPositionAndRotation(transform.position, rot);
                break;
            default:
                Debug.Log("Error with the player direction Enum");
                break;
        }
    }
}
