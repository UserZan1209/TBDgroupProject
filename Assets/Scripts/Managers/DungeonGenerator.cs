using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    #region dungeon generator variables
    [Header("dungeon generator settings")]

    [SerializeField] public string scene_StartingRoom = "StartingRoom";

    [SerializeField] private const int BOSS_ROOM_REQ = 7;

    [SerializeField] private int currantDungeonsCompleted = 0;
    #endregion

    #region dungeon generator storage arrays
    [Header("dungeon storage arrays")]

    //These arrays are used to randomly select a type of room to load
    [SerializeField] private string[] dungeonRoomNames;
    [SerializeField] private string[] bossRoomNames = new string[] { "MainMenu" };

    [SerializeField] public Scene[] dungeonScenes;
    [SerializeField] public Scene[] bossScenes;
    #endregion

    void Awake()
    {
        setArraySize();
    }

    void Update()
    {
        debugInputs();
    }

    private void debugInputs()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            SceneManager.LoadScene(scene_StartingRoom);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            completedRoom();
        }
    }

    private void setArraySize()
    {
        dungeonRoomNames = new string[] { "DungeonOne", "DungeonTwo" };

        dungeonScenes = new Scene[dungeonRoomNames.Length];
        bossScenes = new Scene[bossScenes.Length];
    }

    public void resetCompletedRooms()
    {
        currantDungeonsCompleted = 0;
    }

    public void completedRoom()
    {
        int ranDungonScene = Random.Range(0, dungeonScenes.Length);
        int ranBossScene = Random.Range(0, bossScenes.Length);

        currantDungeonsCompleted++;

        if(currantDungeonsCompleted >= BOSS_ROOM_REQ)
        {
            //load boss room
            Debug.Log("Boss Reached");
            SceneManager.LoadScene(bossRoomNames[ranBossScene]);
        }
        else
        {
            Debug.Log("Currant Room = " + currantDungeonsCompleted.ToString());
            //Load random room
            Debug.Log("rand dung num = " + ranDungonScene);
            SceneManager.LoadScene(dungeonRoomNames[ranDungonScene]);
        }
    }

    
}
