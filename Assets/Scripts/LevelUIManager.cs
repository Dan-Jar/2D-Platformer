using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    public GameObject pauseScreen;

    
    public GameObject levels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            PauseGame();    
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseScreen.SetActive(true);

        AudioManager.instance.Play("PAUSE");

    }

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
    }

    public void restart()
    {   //from the active scene get the index and reload the scene
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void levelsMenu()
    {
        Time.timeScale = 1.0f;
        levels.transform.GetChild(0).gameObject.SetActive(false);
       // Debug.Log(levels.transform.GetChild(0).gameObject.name +" active:" +levels.transform.GetChild(0).gameObject.activeSelf);
        levels.transform.GetChild(1).gameObject.SetActive(true);
        //from the active scene get the index and load the scene
        SceneManager.LoadScene(0);




    }
    public void storeMenu()
    {
        Time.timeScale = 1.0f;
        levels.transform.GetChild(0).gameObject.SetActive(false);
        levels.transform.GetChild(2).gameObject.SetActive(true);
        //from the active scene get the index and load the scene
       // Debug.Log(levels.transform.GetChild(0).gameObject.name + " active:" + levels.transform.GetChild(0).gameObject.activeSelf);
        SceneManager.LoadScene(0);

    }

    public void sceneLoader(string scene)
    {//loads the next scene
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }
}
