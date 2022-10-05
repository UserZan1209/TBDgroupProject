using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resumeButton()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void pauseButton()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }
}
