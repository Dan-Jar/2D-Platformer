using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters;

    public Button unlockButton;

    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        
        foreach (GameObject player in skins)
            player.SetActive(false);


        skins[selectedCharacter].SetActive(true);

        foreach (Character c in characters)
        {
            if (c.price == 0)
                c.isUnlocked = true;

            else
            {
              

                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true; 
            }
        }

        UpdateUI();
    }



    // set current choice none, increments up array, if statement to keep in array bounds, sets next skin true

    public void nextChar()
    {
        skins[selectedCharacter].SetActive(false);

        selectedCharacter++;

        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;

        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI();
    }


    // set current choice none, decrements up array, if statement to keep in array bounds, sets next skin true

    public void prevChar()
    {
        skins[selectedCharacter].SetActive(false);

        selectedCharacter--;

        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;

        skins[selectedCharacter].SetActive(true);
       
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI();
    }


    public void UpdateUI()
    {
        coinsText.text = "Coins:" + PlayerPrefs.GetInt("numCoins", 0);

        if (characters[selectedCharacter].isUnlocked == true)
            unlockButton.gameObject.SetActive(false);

        else
        {

            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + characters[selectedCharacter].price;


            if(PlayerPrefs.GetInt("numCoins", 0) < characters[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;

            }

            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }

        
        
    }


    public void Unlock()
    {
        int currentCoins = PlayerPrefs.GetInt("numCoins", 0);

        int price = characters[selectedCharacter].price;

        PlayerPrefs.SetInt("numCoins", currentCoins - price);

        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);

        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        characters[selectedCharacter].isUnlocked = true;

        UpdateUI();
    }



}
