using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is goint to be a pure class where we get informations off or pass informations in
/// </summary>
/// 

[System.Serializable]
public class Quest
{
    public enum QuestProgress
    {
        NOT_AVAILABLE,
        AVAILABLE,
        ACCEPTED,
        COMPLETE,
        DONE    
    }


    public string title;                //Quest title
    public int id;                      //ID later on I can have all information about the quest just fedding the Id
    public QuestProgress progress;      //later I can compera this state with other states and set it depending on the progression
    //String from quest giver or reciver
    public string description;          //Describes the mission to be completed
    public string hint;                 //Hint to complete the quest
    public string gongratulation;       //congrats message after complete the quest
    public string summary;              //summarize the description

    public int nextQuest;               //Next quest if there is any(chain quest'id')


    public string questObjective;                  //Name of the quest objective
    public int questObjectiveCount;                  //current number of quest objective count
    public int questObjectiveRequirement;           //Riquered amount of quest objectives.

    public int expReward;
    public int goldReward;
    public string itemReward;
}
/*
    Quest has several states 
 
    example:

        NOT_AVAILABLE -> Means this can be unlocked during the game in any point or level that I think is suitable.

        AVAILABLE -> Means it is currently obtainable and can be taken.
        
        ACCEPTED -> Means that the item or task has been approved or agreed upon.
        
        COMPLETED -> Means that all conditions or requirements to achieve or finish the item or task have been met.
        
        DONE -> Means that the item or task has been completed and is no longer available or necessary to accomplish.

*/