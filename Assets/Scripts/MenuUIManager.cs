using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void sceneLoader(string scene)
    {//loads the next scene
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }
}
