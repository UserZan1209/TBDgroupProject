using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuRef;
    // Start is called before the first frame update
    void Start()
    {
        menuRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            toggleMenu();
    }

    private void toggleMenu()
    {
        menuRef.SetActive(!menuRef.activeInHierarchy);

        switch (menuRef.activeInHierarchy)
        {
            case true:
                Time.timeScale = 0.0f;
                break;
            case false:
                Time.timeScale = 1.0f;  
                break;
        }
    }
}
