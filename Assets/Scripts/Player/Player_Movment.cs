using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    //=== Criteria === 

    /*
     
     

     */

    [SerializeField] private float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void movePlayer(float xInput, float yInput)
    {
        transform.Translate(xInput * Time.deltaTime * moveSpeed, 0.0f, yInput * Time.deltaTime * moveSpeed);
    }
}
