using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapons : WeaponSuper
{
    [SerializeField] private GameObject projecitle;
    [SerializeField] private bool isAutomatic = false;
    [SerializeField] private int fireRate = 1;
    // Start is called before the first frame update
    void Awake()
    {
        initWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        pickupTriggerController();

        if(isPickedUp)
        {
            weaponController(isPickedUp);

            if (Input.GetKeyUp(KeyCode.Q))
            {
                dropWeapon();
            }
        }
    }

    #region Weapon Controller
    private void weaponController(bool ispickedup)
    {
        switch (ispickedup)
        {
            case true:
                 if (Input.GetKeyDown(KeyCode.Mouse0))
                 {
                    for(int i = 0; i < fireRate; i++)
                    {
                        float ranX = Random.Range(-40, 40);
                        float ranY = Random.Range(-40, 40);

                        GameObject gm;
                        //Debug.Log(weaponModel.transform.rotation);
                        Quaternion offset = new Quaternion(weaponModel.transform.rotation.x + ranX, weaponModel.transform.rotation.x + ranY,0.0f,1.0f);
                        //Debug.Log(offset);
                        gm = Instantiate(projecitle, weaponMuzzle.transform.position, weaponModel.transform.rotation);
                        gm.GetComponent<projectiles>().weaponRef = weaponModel;
                        gm.transform.parent = null;
                    }
                 }
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
            refreshPlayerWeapons();
            Debug.Log("player picked me up");
            pickUpWeapon(ref playerWeaponContainer.GetComponent<WeaponController>().myWeapons);
        }
    }
}
