using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamer : MonoBehaviour
{
    public int id;
    public int currentLevel;
    public float scoreAccumulated;
    public float scoreCurrentLevel;
    public List<level> levels;
    //For each Gamer there is a list of Levels,
    //and each level has its own index or levelNumber
    //score, time and boolean
    public class level
    {
        public int levelNumber;
        public float score;
        public float time;
        public bool victory;

        public level(int i)
        {  this.levelNumber = i;
           this.score = 0f;
           this.time = 0f;
           this.victory = false;
        }
    }
    //Create a new Gamer from scratch, from main menu.
    //Not appearing in the list of function for the name, it is a constructor
    
    public Gamer(int id)
    {
        this.id = id;
        this.currentLevel = 1;
        this.scoreCurrentLevel = 0f;
        this.scoreAccumulated = 0f;
        this.levels = new List<level>();
        level firstLevel = new level(1);

        firstLevel.score= 0f;
        firstLevel.time = 0f;

        this.levels.Add(firstLevel);
    }
    //Same function with another name  to make it appear in the list of function
    //Automatically created the level one
    public void NewGamer(int id)
    {
        this.id = id;
        this.currentLevel = 1;
        this.levels = new List<level>();
        level firstLevel = new level(1);

        firstLevel.score= 0f;
        firstLevel.time = 0f;

        this.levels.Add(firstLevel);
        //GameManager.instance.SetGamer(this);
        Debug.Log("It should be worrking");
        DontDestroyOnLoad(gameObject);
    }
    //Ask if the new Score is better than the previous one or not
    public bool AskIfItIsaRecord(int level, float score)
    {   
        bool newRecord = false;//by default the level does not have a new score record
        //iteration to get the right level using level number to find it
        foreach (var aLevel in levels)
        {
            if (aLevel.levelNumber == level)//loop through the levels of the gamer to get the right level number
            {
                if (aLevel.score <= score)//compare and verify if new score is better than last one registered
                {
                    aLevel.score = score;
                    aLevel.victory = true;
                    newRecord = aLevel.victory;
                }
            }
        }
        return newRecord;
    }    
    //Save the data of one level that the gamer passed
    //however the level record the new statistics only if
    //the score is better than the previous one
    public void SaveLevel(int level, float score, float time, bool victory)
    {   
        //bool nextLevel = false;//by default the level is not won
        ////iteration to get the right level using level number to find it
        //foreach (var aLevel in levels)
        //{
        //    if (aLevel.levelNumber == level)//loop through the levels of the gamer to get the right level number
        //    {
        //        if (aLevel.score <= score)//compare and edit with new values or not
        //        {
        //            aLevel.score = score;
        //            aLevel.time = time;
        //            aLevel.victory = victory;
        //            nextLevel = aLevel.victory;
        //        }

        //    }
        //}
        //since level is passed, create a new level in the list of levels of the gamer
        //and update current level of the gamer
        if (victory == true)
        {
            //update data 
            this.scoreCurrentLevel = score;
            this.scoreAccumulated += score;
            //saving data in the pc
            string aGamer = "gamer" + this.id.ToString();
            PlayerPrefs.SetInt(aGamer, level);           
            
            aGamer = "gamer" + this.id.ToString() + level.ToString() + "score";
            PlayerPrefs.SetFloat(aGamer, score);

            aGamer = "gamer" + this.id.ToString() + "scoreAccumulated";
            PlayerPrefs.SetFloat(aGamer, this.scoreAccumulated);            
            
            aGamer = "gamer" + this.id.ToString() + "scoreCurrentLevel";
            PlayerPrefs.SetFloat(aGamer, this.scoreCurrentLevel);

            aGamer = "gamer" + this.id.ToString() + level.ToString() + "time";
            PlayerPrefs.SetFloat(aGamer, time);

            //go to the next level
            this.currentLevel = this.currentLevel + 1;

            //save that gamer is on next level
            aGamer = "gamer" + this.id.ToString();
            PlayerPrefs.SetInt(aGamer, this.currentLevel);
            //this.levels.Add(new level(this.currentLevel));
        }
    }



    ////////////////////

    //Activate or deactivate buttons accordingly
    public GameObject button1Empty, button1Level;
    public GameObject button2Empty, button2Level;
    public GameObject button3Empty, button3Level;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("gamer1")==false)//no esta haciendo esto, por lo tanto existe gamer 1
        {
            //turn on empty button 
            button1Empty.SetActive(true);
            button1Level.SetActive(false);
            PlayerPrefs.SetInt("gamer1", 1);//activate gamer 1 for testing

        }
        //IF there is one, take the value n assign it
        else
        {
            Debug.Log("Ah");
            this.currentLevel = PlayerPrefs.GetInt("gamer1");
            button1Empty.SetActive(false);
            button1Level.SetActive(true);
            button1Level.GetComponentInChildren<Text>().text = "Gamer1 Lv " + currentLevel.ToString();
        }

        if (!PlayerPrefs.HasKey("gamer2"))//este si
        {
            //turn on empty button 
            button2Empty.SetActive(true);
            button2Level.SetActive(false);
            //PlayerPrefs.SetInt("gamer2", 1);//activate gamer 2 for testing

        }
        //IF there is one, take the value n assign it
        else
        {
            this.currentLevel = PlayerPrefs.GetInt("gamer2");
            button2Empty.SetActive(false);
            button2Level.SetActive(true);
            button2Level.GetComponentInChildren<Text>().text = "Gamer2 Lv " + currentLevel.ToString();
        }

        if (!PlayerPrefs.HasKey("gamer3"))
        {
            //turn on empty button 
            button3Empty.SetActive(true);
            button3Level.SetActive(false);
            //PlayerPrefs.SetInt("gamer3", 1);//activate gamer 3 for testing

        }
        //IF there is one, take the value n assign it
        else
        {
            this.currentLevel = PlayerPrefs.GetInt("gamer3");
            button3Empty.SetActive(false);
            button3Level.SetActive(true);
            button3Level.GetComponentInChildren<TextMesh>().text = "Lv " + currentLevel.ToString();
        }
    }
    //assign level to button id is given by the button input
    public void goLevelButton(int id)
    {
        this.id = id;
        //SceneManager.GetActiveScene().buildIndex + 1
        string aGamer = "gamer" + id.ToString();
        this.currentLevel = PlayerPrefs.GetInt(aGamer);

        aGamer = "gamer" + id.ToString()+ "scoreAccumulated";
        this.scoreAccumulated = PlayerPrefs.GetFloat(aGamer);

        aGamer = "gamer" + id.ToString() + "scoreCurrentLevel";
        this.scoreCurrentLevel = PlayerPrefs.GetFloat(aGamer);
        Debug.Log("Gamer"+this.id+ " at level"+this.currentLevel+
            " score accumulated "+this.scoreAccumulated+
            "best score for current level "+this.scoreCurrentLevel);
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene(this.currentLevel);

    }



}

