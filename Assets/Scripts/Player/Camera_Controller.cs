using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    [SerializeField] private GameObject playerBodyRef;
    [SerializeField] private float cameraOffset;

    private bool canFollowPlayer = true;
    private Vector3 playerCurPos;
    // Start is called before the first frame update
    void Awake()
    {
        playerBodyRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (canFollowPlayer)
        {
            playerCurPos = getPlayerPosition();
            setCameraPostition();
        }
        else
        {
            Debug.Log("Not Looking for Player");
        }
    }

    private Vector3 getPlayerPosition()
    {
        Vector3 newPos = new Vector3(playerBodyRef.transform.position.x, playerBodyRef.transform.position.y, playerBodyRef.transform.position.z);
        return newPos;
    }

    private void setCameraPostition()
    {
        transform.SetPositionAndRotation(new Vector3(playerCurPos.x += cameraOffset, playerCurPos.y, playerCurPos.z), transform.rotation);
    }
}
