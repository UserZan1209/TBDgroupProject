using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_HUD : MonoBehaviour
{
    [SerializeField] private Canvas menuRef;

    void Start()
    {
        menuRef = GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F6)) // debug
            toggleMenu();

        checkScene();
    }

    private void toggleMenu()
    {
        menuRef.enabled = !menuRef.enabled;
    }

    private void checkScene()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            menuRef.enabled = true;
        }
        else
        {
            menuRef.enabled = false;
        }
    }
}
