using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Quest object can be an NPC Character or anything else that will provide a quest to the receiver
/// </summary>
public class QuestObject : MonoBehaviour
{

    private bool inTrigger = false;

    public List<int> availableQuestIds = new List<int>();               //This can say for any NPC you are the only one who has an available quest ID number 'X' if the ques is already unlocked in the quest list player can go over that and take that quest 
    public List<int> receivableQuestIds = new List<int>();              //This tell to the NPC that it is going to be the one who is going to receive the quest once it is complete.
    [SerializeField] private KeyCode actionbtn = KeyCode.E;               //chose the button to perform the action

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && Input.GetKeyDown(actionbtn))
        {
            Debug.Log("Here ready to get the quest...");
          //  QuestManager.instance.AcceptQuest(availableQuestIds[0]);
        }
    }

    #region Trigger On and Off
    //Flaging on trigger 3d and 2d

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
          //  QuestManager.instance.AddQuestItem("Leave Town", 1);
        }
    }

    //2D

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
    #endregion
}
