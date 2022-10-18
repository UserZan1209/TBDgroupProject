using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon_Movment : MonoBehaviour
{
    [SerializeField] private GameObject armsRef;

    [SerializeField] private float axisInputX;
    [SerializeField] private float axisInputY;

    [SerializeField] private float moveSpeed;

    [SerializeField] private bool canMoveWeapon = false;
 
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 moveVector;

    private void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            canMoveWeapon = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            canMoveWeapon = false;
            startPos = transform.position;
        }

        updateAxis();

        if (canMoveWeapon)
        {
            
            changeObjectPosAndRot();
        }
    }
    private void updateAxis()
    {
        axisInputX = Input.GetAxis("Mouse X");
        axisInputY = Input.GetAxis("Mouse Y");
    }

    private void changeObjectPosAndRot()
    {
        if(axisInputY != 0 || axisInputX != 0)
        {
            transform.Translate(axisInputX * moveSpeed * Time.deltaTime, axisInputY * moveSpeed * Time.deltaTime, 0);
        }
    }
}
