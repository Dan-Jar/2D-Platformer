using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            PlayerManager.numCoins++;

            PlayerPrefs.SetInt("numCoins", PlayerManager.numCoins);
            Destroy(gameObject);
        }








    }

}
