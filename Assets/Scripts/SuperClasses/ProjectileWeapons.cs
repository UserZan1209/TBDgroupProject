using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapons : WeaponSuper
{
    
    // Start is called before the first frame update
    void Awake()
    {
        initWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerWeaponContainer.GetComponent<WeaponController>().myWeapons != null)
        {
            if (Input.GetKeyUp(KeyCode.Q))
                dropWeapon(ref playerWeaponContainer.GetComponent<WeaponController>().myWeapons);
        }

        weaponController(isPickedUp);
        
     
    }

    #region Weapon Controller
    private void weaponController(bool ispickedup)
    {
        switch (ispickedup)
        {
            case true:
                //Debug.Log("Is picked up");
               // if (Input.GetKeyDown(KeyCode.Mouse0) && myWeapons[((int)curWeaponNum)].GetComponent<Melee>() == null)
               // {
                    //fire
                 //   Debug.Log("Weapon firing");
                    //GameObject gm;
                    //gm = Instantiate(projectileObject, weaponMuzzle.transform.position, weaponModel.transform.rotation);
                    //gm.GetComponent<projectiles>().weaponRef = weaponModel;
                    //gm.transform.parent = null;

                //}
                break;
            case false:
                //Debug.Log("Is not picked up");
                break;
        }

    }
    #endregion

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            pickUpWeapon(ref playerWeaponContainer.GetComponent<WeaponController>().myWeapons);
            isPickedUp = true;
        }
    }
}
