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
    [SerializeField] private GameObject weaponFist;


    [SerializeField] private int ammoReserve;
    [SerializeField] private int ammoCurrantMagazineMax;
    [SerializeField] private int ammoCurrantMagazine;
    [SerializeField] private const int MAX_WEAPONS = 2;

    [SerializeField] private float curWeaponNum;

    [SerializeField] private bool hasMoreThanOneWeapon = false;

    [SerializeField] public GameObject[] myWeapons;

    [HideInInspector] private WeaponSuper fist;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        myWeapons = new GameObject[MAX_WEAPONS];
        //Debug.Log(myWeapons.Length);

        #region declare fist weapon;
        weaponFist.AddComponent<WeaponSuper>();
        weaponFist.GetComponent<WeaponSuper>().name = "Fist";
        weaponFist.GetComponent<WeaponSuper>().baseDamage = 5;

        myWeapons[0] = weaponFist;
        #endregion
        
    }

    // Update is called once per frame
    void Update()
    {
       // checkWeapons();
        ScrollWheelController();
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
        if (hasMoreThanOneWeapon)
        {
            if (myWeapons.Length > 0)
            {
                for (int i = 0; i < myWeapons.Length && myWeapons[i].gameObject != null; i++)
                {
                    myWeapons[i].SetActive(false);
                }
            }

            for (int i = 0; i < myWeapons.Length && myWeapons[i].gameObject != null; i++)
            {
                if (i == curWeaponNum)
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
}
