using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    
    //ref to game over screen 
    public GameObject gameOverScreen;
  
    // Holds players starting position 
    public static Vector2 checkpointPos = new Vector2(-16, -2);


    // holds coin num
    public static int numCoins;

    
    // ref to coin text in canvas
    public TextMeshProUGUI coinText;




    private void Awake()
    {

        numCoins = PlayerPrefs.GetInt("numCoins", 0);

        isGameOver = false;

        GameObject.FindGameObjectWithTag("Player").transform.position = checkpointPos;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = numCoins.ToString();


        // enabling gameover Canvas
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }


    // Func to replay level

    public void replayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
