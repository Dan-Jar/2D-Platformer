using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuEvents : MonoBehaviour
{

    private void Start() 
    {
        Time.timeScale = 1;
    }







   public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
