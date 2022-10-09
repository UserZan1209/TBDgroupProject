using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject bodyRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "Projectile":
                bodyRef.SetActive(false);
                break;
        }
    }

    public void takeDamage(int dmg)
    {
        //Temp
        bodyRef.SetActive(false);
    }
}
