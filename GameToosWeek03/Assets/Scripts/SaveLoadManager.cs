using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    public GameData gd;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveDataManager.Save(gd);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            gd = SaveDataManager.Load();
        }

    }
}
