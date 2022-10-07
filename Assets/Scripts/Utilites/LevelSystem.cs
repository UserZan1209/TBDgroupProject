using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    //=== Criteria === 

    /*
     
    *Level up through exp Points []
    *cap level at 50 []
    *gain skill points through levels []

     */

    #region Base Stats
    [Header("Base Stats")]
    [SerializeField] private int healthPoints;

    [SerializeField] private float stamina;
    #endregion
    #region Level Variables
    [Header("Level Variables")]
    [SerializeField] private int Level;
    [SerializeField] private int totalExp;
    [SerializeField] private int thisLevelExpGained;
    [SerializeField] private int xpCap;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        setBaseStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            gainExp(50);
        }
    }
    private void setBaseStats()
    {
        Level = 1;
        xpCap = Level * 100;
        healthPoints = 10;
        stamina = 10;
    }
    private void increaseBaseStats(int level)
    {
        healthPoints++;
        stamina++;
        xpCap = Level * 100;
    }
    private void gainExp(int xp)
    {
        //increase exp
        totalExp += xp;
        thisLevelExpGained += xp;
        //check for level up
        if(thisLevelExpGained >= xpCap && Level < 50)
        {
            Level++;

            int remainingXP = thisLevelExpGained - xpCap;
            thisLevelExpGained = 0;
            thisLevelExpGained += remainingXP;
            
            //alter exp cap
            increaseBaseStats(Level);
        }

    }
}
