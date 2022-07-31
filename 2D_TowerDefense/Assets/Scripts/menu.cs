using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    [Header("Assign Setting Menu")]
    public GameObject settingMenu;
    public GameObject gamersMenu;
    public GameObject instructionMenu;

    //public Image img_Instruction;
    //public Button btn_BackToMain;


    public void Start()
    {
        //settingMenu.SetActive(false);
        settingMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, -15f);
        gamersMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, -15f);
        instructionMenu.SetActive(false);
        //img_Instruction.enabled = false;
        //btn_BackToMain.enabled = false;
    }
    public void GoToTheGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GoToTheSettigMenu() 
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

    public void GoBackToTheMainMenu()//for return button that is on setting menu
    {
        //settingMenu.SetActive(false);
        settingMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, 0f);
        instructionMenu.SetActive(false);
    }    
    public void GoBackToTheMainMenuFromGamersMenu()//for return button that is on gamers menu
    {
        //settingMenu.SetActive(false);
        gamersMenu.transform.position = new Vector3(settingMenu.transform.position.x, settingMenu.transform.position.y, 0f);
    }
    public void GoToInstruction()
    {
        instructionMenu.SetActive(true);
        //img_Instruction.enabled = true;
        //btn_BackToMain.enabled = true;
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
