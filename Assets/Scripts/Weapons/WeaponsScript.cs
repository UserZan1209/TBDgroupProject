using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScripts : MonoBehaviour
{
    int goodTier;
    int badTier;
    int bestTier;
    [HideInInspector] private enum weaponTiers {best, great, bad};
    weaponTiers myTier;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 2);

        switch (rand)
        {
            case 0:
                myTier = weaponTiers.bad;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void setPlayerWeapon()
    {

    }
}
