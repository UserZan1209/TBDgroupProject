using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeObject : MonoBehaviour
{
    //=== Criteria === 

    /*
      1) save the oriantation of the door []
      2) randomly select from a set of scene rooms [x]
      3) load the next scene setting the players spawn point to the correct door (turn off trigger until room cleared) []

      x1) keep track of total rooms and when the rooms reach 8 load a boss rooom []

     */

    private const int MAX_SCENES = 2; // TEMP - delete when finished

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private int generateRandomSceneNumber(int MaxSceneNumber)
    {
        int rand = Random.Range(0, MAX_SCENES);
        //Debug.Log(rand);
        return rand;
    }

    private void changeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            changeScene(generateRandomSceneNumber(MAX_SCENES));
            
        }
    }
}
