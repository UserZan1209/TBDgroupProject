using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private int weaponDamage;
    [SerializeField] private Camera mainCamRef;
    // Start is called before the first frame update
    void Start()
    {
        mainCamRef = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(mainCamRef.transform.position, mainCamRef.transform.forward, Color.cyan);
        if (Input.GetKey(KeyCode.Mouse0))
            attack();
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
}
