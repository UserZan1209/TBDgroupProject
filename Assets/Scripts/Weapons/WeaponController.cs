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
    [SerializeField] private GameObject[] myWeapons;

    [SerializeField] private int ammoReserve;
    [SerializeField] private int ammoCurrantMagazineMax;
    [SerializeField] private int ammoCurrantMagazine;

    [SerializeField] private float curWeaponNum;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        myWeapons = new GameObject[transform.childCount];
        Debug.Log(myWeapons.Length);
        checkWeapons(); 
    }

    // Update is called once per frame
    void Update()
    {
        weaponController();
        if (!weaponModel)
            FindWeapon();
        ScrollWheelController();
        checkWeapons();

    }

    private void weaponController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && myWeapons[((int)curWeaponNum)].GetComponent<Melee>() == null)
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

    private void ScrollWheelController()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {

            if (curWeaponNum < myWeapons.Length)
            {
                curWeaponNum++;
                return;
            }
            else if(curWeaponNum == myWeapons.Length)
            {
                curWeaponNum = myWeapons.Length;
            }
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (curWeaponNum > 0)
            {
                curWeaponNum--;
                return;
            }
            else
            {
                curWeaponNum = 0;
            }
        }
    }

    private void checkWeapons()
    {
        for (int i = 0; i < myWeapons.Length; i++)
        {
            myWeapons[i] = transform.GetChild(i).gameObject;
        }

        if (myWeapons.Length > 0)
        {
            for (int i = 0; i < myWeapons.Length; i++)
            {
                myWeapons[i].SetActive(false);
            }
        }

        for(int i = 0; i < myWeapons.Length; i++)
        {
            if(i == curWeaponNum)
            {
                myWeapons[i].SetActive(true);
                break;
            }
            else
            {
                if (i != curWeaponNum && myWeapons[i].activeInHierarchy == true)
                {
                    myWeapons[i].SetActive(false);
                }
            }
        }
    }
}
