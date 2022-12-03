using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        
        foreach (GameObject player in skins)
            player.SetActive(false);


        skins[selectedCharacter].SetActive(true);
    }



    // set current choice none, increments up array, if statement to keep in array bounds, sets next skin true

    public void nextChar()
    {
        skins[selectedCharacter].SetActive(false);

        selectedCharacter++;

        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

    }


    // set current choice none, decrements up array, if statement to keep in array bounds, sets next skin true

    public void prevChar()
    {
        skins[selectedCharacter].SetActive(false);

        selectedCharacter--;

        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

    }
}
