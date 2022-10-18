using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : WeaponSuper
{
    [SerializeField] private int weaponDamage;
    [SerializeField] private Camera mainCamRef;
    [SerializeField] private CapsuleCollider attackTrigger;


    // Start is called before the first frame update
    void Start()
    {
        mainCamRef = Camera.main;
        initWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        pickupTriggerController();
        if (isPickedUp)
        {
            attackTrigger.enabled = true;
            
        }
        else
        {
            attackTrigger.enabled = false;
        }

        Debug.DrawRay(mainCamRef.transform.position, mainCamRef.transform.forward, Color.cyan);
        if (Input.GetKey(KeyCode.Mouse0))
            attack();

        if (isPickedUp)
        {
            weaponMovement();
            if (Input.GetKeyUp(KeyCode.Q))
            {
                dropWeapon();
                isPickedUp = false;
            }
        }
    }

    private void attack()
    {
        RaycastHit hit;
       
        if(Physics.Raycast(mainCamRef.transform.position, mainCamRef.transform.forward, out hit, weaponRange))
        {
            Debug.Log("Hit: " + hit.transform.name);
            if (hit.transform.gameObject.tag == "Enemy") 
            {
                hit.transform.gameObject.GetComponent<EnemyController>().takeDamage(0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !isPickedUp)
        {
            refreshPlayerWeapons();
            Debug.Log("player picked me up");
            pickUpWeapon(ref playerWeaponContainer.GetComponent<WeaponController>().myWeapons);
            isPickedUp = true;
        }
    }
}
