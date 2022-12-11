using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    
    //ref to game over screen 
    public GameObject gameOverScreen;
  
    // Holds players starting position 
    public static Vector2 checkpointPos = new Vector2(-24, -13);


    // holds coin num
    public static int numCoins;

    
    // ref to coin text in canvas
    public TextMeshProUGUI coinText;

    //ref to cinemachine camera

    public CinemachineVirtualCamera VCam;



    // ref to players

    public GameObject[] playerPreSets;
   
    // store char number
    int charIndex;


    private void Awake()
    {
        charIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        GameObject player =  Instantiate(playerPreSets[charIndex], checkpointPos, Quaternion.identity);

        VCam.m_Follow = player.transform;

        numCoins = PlayerPrefs.GetInt("numCoins", 0);

        isGameOver = false;

        

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
