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
    public List<Quest> questList = new List<Quest>();           //Master quest list all existing quests
    public List<Quest> currentQuestList = new List<Quest>();    //List of quests that the player or receiver own


    //private variables for our QuestObjects


    #region Unity Functions
    //making sure that we do not have a second copy of the Quest manager into the scene by making it sigleton
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

    #endregion

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
        foreach (var quest in questList)
        {
            if (quest.id == questID && quest.progress == Quest.QuestProgress.AVAILABLE)
            {
                quest.progress = Quest.QuestProgress.ACCEPTED;
                currentQuestList.Add(quest);
                break;
            }
        }
    }

    //GIVE UP QUEST
    public void GiveUpQuest(int questID)
    {
        foreach (var currQuest in currentQuestList)
        {
            if (currQuest.id == questID && currQuest.progress == Quest.QuestProgress.ACCEPTED)
            {
                currQuest.progress = Quest.QuestProgress.AVAILABLE;
                currQuest.questObjectiveCount = 0;
                currentQuestList.Remove(currQuest);
                break;
            }
        }
    }

    //COMPLETE QUEST

    public void CompleteQuest(int questID)
    { 
        foreach(var currQuest in currentQuestList)
        {
            if (currQuest.id == questID && currQuest.progress == Quest.QuestProgress.COMPLETE)
            {
                currQuest.progress = Quest.QuestProgress.DONE;
                currentQuestList.Remove(currQuest);
            }
        }
    }

    //ADD ITEMS (questObjectiveRequirement)

    public void AddQuestItem(string questObjective, int itemAmount)
    {
        //Quest objective is what we need to do/collect/kill/get at to count as a quest progression in order to complet it
        //intem amount is how many objectives we have acomplished

        //Include completed requirements in the quest objective count to increase the total number of objectives needed.
        foreach (var quest in currentQuestList)
        {
            if (quest.questObjective == questObjective && quest.progress == Quest.QuestProgress.ACCEPTED)
            {
                quest.questObjectiveCount += itemAmount;
                if (quest.questObjectiveCount < quest.questObjectiveRequirement)
                {
                    break;
                }
            }

            //check if all the objective has been achived, if so change the progress status to completed
            if (quest.questObjectiveCount >= quest.questObjectiveRequirement && quest.progress == Quest.QuestProgress.ACCEPTED)
            {
                quest.progress = Quest.QuestProgress.COMPLETE;
                break;
            }
        }
    }

    //REMOVE ITEMS (usefull for inventory system)
}
