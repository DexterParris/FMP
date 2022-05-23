using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainButtonScript : MonoBehaviour
{
    public static string currentNight;
    public GameObject OptionsMenu;
    public GameObject MainMenu;
    public GameObject CustomMenu;

    public GameObject selectedButton;
    public GameObject backButton;
    public GameObject customBackButton;
    public Animator anim;
    public TextMeshProUGUI continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("currentNight"))
        {
            PlayerPrefs.SetString("currentNight","Night 1");
        }

        currentNight = PlayerPrefs.GetString("currentNight");
        if (PlayerPrefs.GetString("currentNight") == "Custom Night")
        {
            PlayerPrefs.SetString("currentNight", "Night 6");
        }
        continueButton.text = "Continue " + currentNight;
        selectedButton.GetComponent<Button>().Select();
    }

    void Update()
    {
        //this code is for testing purposes only
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetString("currentNight", "Night 1");
            currentNight = PlayerPrefs.GetString("currentNight");
            continueButton.text = "Continue " + currentNight;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.SetString("currentNight", "Night 2");
            currentNight = PlayerPrefs.GetString("currentNight");
            continueButton.text = "Continue " + currentNight;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerPrefs.SetString("currentNight", "Night 3");
            currentNight = PlayerPrefs.GetString("currentNight");
            continueButton.text = "Continue " + currentNight;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayerPrefs.SetString("currentNight", "Night 4");
            currentNight = PlayerPrefs.GetString("currentNight");
            continueButton.text = "Continue " + currentNight;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayerPrefs.SetString("currentNight", "Night 5");
            currentNight = PlayerPrefs.GetString("currentNight");
            continueButton.text = "Continue " + currentNight;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayerPrefs.SetString("currentNight", "Night 6");
            continueButton.text = "Continue " + currentNight;
            currentNight = PlayerPrefs.GetString("currentNight");
        }

    }

    public void OpenOptionsMenu()
    {
        OptionsMenu.SetActive(true);
        backButton.GetComponent<Button>().Select();
        MainMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        OptionsMenu.SetActive(false);
        CustomMenu.SetActive(false);
        MainMenu.SetActive(true);
        selectedButton.GetComponent<Button>().Select();
    }

    public void OpenCustomMenu()
    {
        CustomMenu.SetActive(true);
        customBackButton.GetComponent<Button>().Select();
        MainMenu.SetActive(false);
    }

    public void ExitGame()
    {
        anim.SetTrigger("ToBlack");
        Application.Quit();
    }

    public void PlayGame()
    {
        StartCoroutine(ChangeScene());
    }

    public void NewGame()
    {
        PlayerPrefs.SetString("currentNight","Night 1");
        StartCoroutine(ChangeScene());
    }

    public void CustomNight()
    {
        PlayerPrefs.SetString("currentNight", "Custom Night");
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        anim.SetTrigger("ToBlack");
        
        yield return new WaitForSeconds(1.5f);

        Game();
        
    }

    void Game()
    {
        SceneManager.LoadScene("Night 1");

    }


}
