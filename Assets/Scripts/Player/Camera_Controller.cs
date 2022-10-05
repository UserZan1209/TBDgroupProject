using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    [SerializeField] private GameObject playerBodyRef;
    [SerializeField] private float sensitivity;
    // Start is called before the first frame update
    void Awake()
    {
        playerBodyRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") > 0.0f)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity);
        }
        else if(Input.GetAxis("Mouse X") < 0.0f) 
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity);
        }
    }
}
