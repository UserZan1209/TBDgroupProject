using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : WeaponSuper
{
    #region melee weapon variables
    [Header("melee weapon variables")]
    [SerializeField] private int weaponDamage;
    [SerializeField] private CapsuleCollider attackTrigger;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        initWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        pickupTriggerController();


        if (isPickedUp)
        {
            weaponMovement();

            if (Input.GetKeyDown(KeyCode.Mouse0))
                attack();

            if (Input.GetKeyUp(KeyCode.Q))
            {
                isPickedUp = false;
                dropWeapon();
            }
        }
    }

    #region combat functions
    private void attack()
    {
        enableBladeCollider();
    }

    private void enableBladeCollider() 
    {
        if (isPickedUp)
        {
            attackTrigger.enabled = true;

        }
        else
        {
            attackTrigger.enabled = false;
        }
    }
    #endregion
}
