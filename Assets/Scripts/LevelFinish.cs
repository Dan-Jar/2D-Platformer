using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelFinish : MonoBehaviour
{

    public GameObject LevelMenu;
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag =="Player") {
            Debug.Log("hit");
           Time.timeScale = 0.0f;
           LevelMenu.transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }

    private void onTriggerExit2D(Collider2D collision)
    {

    }
}
