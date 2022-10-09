using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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

    [SerializeField] public float weaponRange;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
