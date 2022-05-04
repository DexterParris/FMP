using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainButtonScript : MonoBehaviour
{
   
    public GameObject OptionsMenu;
    public GameObject MainMenu;

    public GameObject selectedButton;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        selectedButton.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOptionsMenu()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
        backButton.GetComponent<Button>().Select();
    }

    public void OpenMainMenu()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
        selectedButton.GetComponent<Button>().Select();
    }

    public void ExitGame()
    {
        print("Exited The Game 👍");
        Application.Quit();
    }

    
}
