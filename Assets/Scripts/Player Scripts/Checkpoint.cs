using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   // sets players pos when they collid w/ checkpoint obj
   private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.transform.tag == "Player")
        {
            PlayerManager.checkpointPos = transform.position;

            // change color of checkpoint to black
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }





   
}
