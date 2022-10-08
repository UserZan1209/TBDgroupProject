using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectiles : MonoBehaviour
{
    [HideInInspector] private Rigidbody myRb;
    [SerializeField] private float forceMultiplyer;
    [SerializeField] private float counter;

    [HideInInspector] public GameObject weaponRef;
    // Start is called before the first frame update
    void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        myRb.AddForce(weaponRef.transform.forward * forceMultiplyer);
        counter += Time.deltaTime;
        //Debug.Log(counter);    
        //destroy when counter reaches x amount
    }
}
