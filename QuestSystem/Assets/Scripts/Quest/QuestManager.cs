using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This will be the management objct or managment script where we pass in all our data for all scripts
/// We are going to List all the quests then we can read the data later, pass it to another list then we have stuffs to compare
/// QuestManager will be a static game obj so it will be persistent is every scene
/// </summary>
public class QuestManager : MonoBehaviour
{

    public static QuestManager instance;
    public List<Quest> questList = new List<Quest>();           //Master quest list
    public List<Quest> currentQuestList = new List<Quest>();    //Master quest list


    //private variables for our QuestObjects
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    // BOOLS

    public bool RequestAvailableQuest(int questID)
    {
        if(questList is null)
        {
            return false;
        }

        foreach (var quest in questList)
        {
            if (quest.id == questID && quest.progress == Quest.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }

        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        if (questList is null)
        {
            return false;
        }

        foreach (var quest in questList)
        {
            if (quest.id == questID && quest.progress == Quest.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }

        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        if (questList is null)
        {
            return false;
        }

        foreach (var quest in questList)
        {
            if (quest.id == questID && quest.progress == Quest.QuestProgress.COMPLETE)
            {
                return true;
            }
        }

        return false;
    }

    //ACCEPT QUEST 

    public void AcceptQuest(int questID)
    {
    
    }

    //GIVE UP QUEST


    //COMPLETE QUEST


    //ADD ITEMS

    public void AddQuestItem(string questObjective, int itemAmount)
    {
        foreach (var quest in currentQuestList)
        {
            if (quest.questObjective == questObjective && quest.progress == Quest.QuestProgress.ACCEPTED)
            {
                quest.questObjectiveCount += itemAmount;
            }

            if (quest.questObjectiveCount >= quest.questObjectiveRequirement && quest.progress == Quest.QuestProgress.ACCEPTED)
            {
                quest.progress = Quest.QuestProgress.COMPLETE;
            }
        }
    }

    //REMOVE ITEMS
}
