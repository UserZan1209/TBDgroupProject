using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroyOnLoad>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroyOnLoad>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroyOnLoad>()[i].name == this.gameObject.name)
                {
                    Destroy(Object.FindObjectsOfType<DontDestroyOnLoad>()[i].gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
