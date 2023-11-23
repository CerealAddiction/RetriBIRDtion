using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    public bool Enemy = false;  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Kollar om det som har kolliderat med oss har taggen player
        if (collision.gameObject.CompareTag("Player"))
        {
            //Dödar spelaren om den har kolliderat med spelobjektet
            //Destroy(collision.gameObject);
            //TODO: Make this more cool


            if (Enemy)
            {
                collision.gameObject.GetComponent<Player_Movement>().Death();
           
            }
        }
    }
}
