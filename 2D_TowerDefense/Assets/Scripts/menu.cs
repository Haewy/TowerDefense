using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject settingMenu;
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
}
