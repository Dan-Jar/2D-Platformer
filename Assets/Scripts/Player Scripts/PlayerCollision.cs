using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    // Called when player collides with certain objects
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.tag == "Enemy")
        {
           
            //calling PlayerMaanger scripts isGameOver func and setting it to true 
            PlayerManager.isGameOver = true;


            //disable player movement when game ends

            gameObject.SetActive(false);
        }




    }






}


