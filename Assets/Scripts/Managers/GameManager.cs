using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GAMEMANAGER variables
    [Header("GAMEMANAGER variables")]
    [SerializeField] private GameObject playerReference;
    [SerializeField] private GameObject dungeonGeneratorReference;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void init()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
    }
}
