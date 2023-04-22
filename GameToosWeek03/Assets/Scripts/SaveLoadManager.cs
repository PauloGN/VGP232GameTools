using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoadManager : MonoBehaviour
{

    public GameData gd;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveDataBinaryM.Save(gd);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            gd = SaveDataBinaryM.Load();
        }
    }
}

[CustomEditor(typeof(SaveLoadManager))]
public class SaveAndLoad : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SaveLoadManager saveUI = (SaveLoadManager)target;
        if (GUILayout.Button("Serialize to Binary Data"))
        {
            SaveDataBinaryM.Save(saveUI.gd);
        }

        if (GUILayout.Button("Load Binary data"))
        {
            SaveDataBinaryM.Load();
        }

        if (GUILayout.Button("Serialize to json Data"))
        {
            SaveDataManager.Save(saveUI.gd);
        }

        if (GUILayout.Button("Load json data"))
        {
            SaveDataManager.Load();
        }

    }

}