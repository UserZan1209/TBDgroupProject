using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    #region Weapon Variables
    [Header("Weapon Variables")]
    [SerializeField] private string weaponName;

    [SerializeField] private GameObject weaponModel;
    [SerializeField] private GameObject weaponMuzzle;
    [SerializeField] private GameObject projectileObject;

    [SerializeField] private int ammoReserve;
    [SerializeField] private int ammoCurrantMagazineMax;
    [SerializeField] private int ammoCurrantMagazine;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponController();
        if (!weaponModel)
            FindWeapon();
    }

    private void weaponController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //fire
            Debug.Log("Weapon firing");
            GameObject gm;
            gm = Instantiate(projectileObject, weaponMuzzle.transform.position, weaponModel.transform.rotation);
            gm.GetComponent<projectiles>().weaponRef = weaponModel;
            gm.transform.parent = null;

        }
    }

    private void FindWeapon()
    {
        weaponModel = transform.GetChild(0).gameObject;
        if (!weaponModel)
            Debug.Log("No Weapons");
    }
}
