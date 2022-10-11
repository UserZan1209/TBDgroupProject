using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSuper : MonoBehaviour
{
    #region Weapon Variables
    [Header("Weapon Variables")]
    [SerializeField] public string weaponName;

    [SerializeField] private GameObject playerRef;
    [SerializeField] public GameObject playerWeaponContainer;
    [SerializeField] private GameObject weaponModel;
    [SerializeField] private GameObject weaponMuzzle;
    [SerializeField] private GameObject projectileObject;

    [SerializeField] private int ammoReserve;
    [SerializeField] private int ammoCurrantMagazineMax;
    [SerializeField] private int ammoCurrantMagazine;
    [SerializeField] public int baseDamage;

    [SerializeField] public float weaponRange;
    #endregion

    #region Pickup Variables
    [Header("Pickup Variables")]
    [SerializeField] public bool isPickedUp = false;
    #endregion

    public void initWeapon()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        playerWeaponContainer = playerRef.GetComponent<Player_Movment>().myWeaponContainer;
    }

    #region Pickup Functions
    public void pickUpWeapon(ref GameObject[] playerWeapons)
    {
        Debug.Log("pickup up " + weaponName);
        transform.parent = playerWeaponContainer.transform;
        playerWeapons[0] = gameObject;
        isPickedUp = true;


    }

    public void dropWeapon(ref GameObject[] playerWeapons)
    {
        if(transform.parent != null && isPickedUp)
        {
            for(int i = 0; i < playerWeapons.Length; i++)
            {
                if(playerWeapons[i].gameObject == gameObject)
                {
                    transform.parent = null;
                    isPickedUp = false;
                    Debug.Log(gameObject.name + " was dropped");
                }
            }

        }
    }
    #endregion
}
