using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [Header("Assign Setting Menu")]
    public GameObject settingMenu;

    public void Start()
    {
        settingMenu.SetActive(false);
    }
    public void GoToTheGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GoToTheMenu() 
    {
        Debug.Log("ESTA WEAAAAAAAAAAAAAAAAAAA");
        settingMenu.SetActive(true);
    }
    public void GoBackToTheMainMenu()
    {
        settingMenu.SetActive(false);
    }

    public void ExitTheGame()
    {
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
    }
}
