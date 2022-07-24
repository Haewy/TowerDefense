using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    public int id;
    public int currentLevel;
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
    //Automatically created the level one
    public Gamer(int id)
    {
        this.id = id;
        this.currentLevel = 1;
        this.levels = new List<level>();
        level firstLevel = new level(1);

        firstLevel.score= 0f;
        firstLevel.time = 0f;

        this.levels.Add(firstLevel);
    }    
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
    public void SaveLevel(int level, float score, float time)
    {   
        bool nextLevel = false;//by default the level is not won
        //iteration to get the right level using level number to find it
        foreach (var aLevel in levels)
        {
            if (aLevel.levelNumber == level)//loop through the levels of the gamer to get the right level number
            {
                if (aLevel.score <= score)//compare and edit with new values or not
                {
                    aLevel.score = score;
                    aLevel.time = time;
                    aLevel.victory = true;
                    nextLevel = aLevel.victory;
                }

            }
        }
        //since level is passed, create a new level in the list of levels of the gamer
        //and update current level of the gamer
        if (nextLevel == true)
        {
            this.currentLevel = this.currentLevel + 1;
            this.levels.Add(new level(this.currentLevel));
        }
    }
}
