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
    [SerializeField] public GameObject[] playersWeapons;

    [SerializeField] public GameObject weaponModel;
    [SerializeField] public GameObject weaponMuzzle;

    [HideInInspector] private Rigidbody myRb;

    [SerializeField] private int ammoReserve;
    [SerializeField] private int ammoCurrantMagazineMax;
    [SerializeField] private int ammoCurrantMagazine;
    [SerializeField] public int baseDamage;

    [SerializeField] public float weaponRange;
    #endregion

    #region Pickup Variables
    [Header("Pickup Variables")]
    [SerializeField] public bool isPickedUp = false;
    [SerializeField] private SphereCollider pickUpTrigger;
    #endregion

    public void initWeapon()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        playerWeaponContainer = playerRef.GetComponent<Player_Movment>().myWeaponContainer;
        myRb = gameObject.GetComponent<Rigidbody>();
        myRb.useGravity = false;
        refreshPlayerWeapons();
    }

    #region Pickup Functions
    public void pickUpWeapon(ref GameObject[] playerWeapons)
    {
        for(int i = 0; i < playersWeapons.Length; i++)
        {
            if(playersWeapons[i] == null && !isPickedUp)
            {
                transform.parent = playerWeaponContainer.transform;
                playerWeapons[i] = this.gameObject;
                isPickedUp = true;
                return;
            }
            
        }
    }

    public void dropWeapon()
    {
        if (transform.parent != null && isPickedUp)
        {
            this.transform.parent = null;
            isPickedUp = false;
            enableGravityWhenDropped();

        }
    }

    public void refreshPlayerWeapons()
    {
        playersWeapons = playerWeaponContainer.GetComponent<WeaponController>().myWeapons;
    }

    private void enableGravityWhenDropped()
    {
        myRb.useGravity = true;
    }

    public void pickupTriggerController()
    {
        if (isPickedUp)
        {
            pickUpTrigger.enabled = false;
        }
        else
            pickUpTrigger.enabled = true;
    }
    #endregion
}
