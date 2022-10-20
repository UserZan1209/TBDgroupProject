using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region start new game
    public void loadNewGame()
    {
        //Debug.Log("loading...");
        SceneManager.LoadScene("StartingRoom");
    }
    #endregion
}
