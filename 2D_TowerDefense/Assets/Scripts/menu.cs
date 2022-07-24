using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [Header("Assign Setting Menu")]
    public GameObject settingMenu;
    public GameObject gamersMenu;

    public void Start()
    {
        //settingMenu.SetActive(false);
        settingMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, -15f);
        gamersMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, -15f);
    }
    public void GoToTheGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GoToTheMenu() 
    {
        Debug.Log("ESTA WEAAAAAAAAAAAAAAAAAAA");
        //settingMenu.SetActive(true);
        settingMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, 120f);
    }    
    public void GoToTheGamerMenu() //
    {
        Debug.Log("ESTA WEAAAAAAAAAAAAAAAAAAA");
        //settingMenu.SetActive(true);
        gamersMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, 120f);
    }

    public void GoBackToTheMainMenu()//add return button
    {
        //settingMenu.SetActive(false);
        settingMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, 0f);
    }

    public void ExitTheGame()
    {
        //Application.Quit();
#if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
