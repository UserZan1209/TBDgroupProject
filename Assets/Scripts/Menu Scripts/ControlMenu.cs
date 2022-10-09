using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    [SerializeField] private Image menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menu.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            menu.enabled= false;
        }
    }
}
