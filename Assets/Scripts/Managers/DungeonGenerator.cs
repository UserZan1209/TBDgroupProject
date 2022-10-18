using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] public string scene_StartingRoom = "StartingRoom";

    [SerializeField] private const int BOSS_ROOM_REQ = 7;

    [SerializeField] private int currantDungeonsCompleted = 0;

    [SerializeField] public Scene[] scenes;


    [SerializeField] private string[] dungeonRoomNames = new string[] { "RoomOne", "DungeonOne" };
    [SerializeField] private string[] bossRoomNames = new string[] { "MainMenu" };

    [SerializeField] public Scene[] dungeonScenes;
    [SerializeField] public Scene[] bossScenes;

    // Start is called before the first frame update
    void Awake()
    {
       dungeonScenes = new Scene[dungeonRoomNames.Length];
       bossScenes = new Scene[bossScenes.Length];
    }

    // Update is called once per frame
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
