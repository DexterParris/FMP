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

    public GameObject selectedButton;
    public GameObject backButton;
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
        continueButton.text = "Continue " + currentNight;
        selectedButton.GetComponent<Button>().Select();
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
        MainMenu.SetActive(true);
        selectedButton.GetComponent<Button>().Select();
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

    IEnumerator ChangeScene()
    {
        anim.SetTrigger("ToBlack");
        
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(PlayerPrefs.GetString("currentNight"));
    }

    

}
