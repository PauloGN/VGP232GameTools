using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace FoxTools
{
    public class RenameGameObj : EditorWindow
    {

        //Variables

        GameObject[] selectedObjects;
        string wantedPrefix;
        string wantedName;
        string wantedSufix;
        int startNumbering;
        bool enumerateFromZero = true;
        bool allowNumbering;

        //Path in editor tab and also the function to be called when clicked to open window
        [MenuItem("FoxTools/Game Tools/Rename Game Objects")]
        public static void RenameTool()
        {
            EditorWindow editorWindow = GetWindow<RenameGameObj>();
            if (editorWindow != null)
            {
                editorWindow.minSize = new Vector2(600, 300);
                editorWindow.maxSize = new Vector2(900, 445);
                editorWindow.titleContent.text = "Rename Game Objects";
                editorWindow.Show();
            }
        }

        private void OnGUI()
        {
            //Get size of array based on length
            int size = Selection.gameObjects.Length;
            selectedObjects = new GameObject[size];
            //Getting references from selected objects in hierarchy tab
            selectedObjects = Selection.gameObjects;

            //Layout the window
            ///*****
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space(10);
            //Show number of selected objects
            EditorGUILayout.LabelField(size + " Selected");
            EditorGUILayout.Space(5);
            //Add text fields for prefix, name, and suffix
            wantedPrefix = EditorGUILayout.TextField("Prefix: ", wantedPrefix);
            wantedName = EditorGUILayout.TextField("Name: ", wantedName);
            wantedSufix = EditorGUILayout.TextField("Sufix: ", wantedSufix);
            allowNumbering = EditorGUILayout.Toggle("Add numbering", allowNumbering);

            if (allowNumbering)
            {
                enumerateFromZero = EditorGUILayout.Toggle("Enumerate from zero", enumerateFromZero);
                //Add an integer field for starting number if not enumerating from zero
                if (!enumerateFromZero)
                {
                    startNumbering = EditorGUILayout.IntField("Number starts from: ", startNumbering);
                }
            }
            EditorGUILayout.Space(10);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(5);
            EditorGUILayout.EndHorizontal();
            ///*****

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space(5);
            //Add Apply button to apply rename logic to selected objects
            if (GUILayout.Button("Apply name convention"))
            {
                RenameSelectedGameObjects(size);
            }
            EditorGUILayout.EndVertical();


            //Refresh window
            GetWindow<RenameGameObj>().Repaint();
        }

        void RenameSelectedGameObjects(int indexSize)
        {

            if (indexSize == 0)
            {
                Debug.Log("No object selected");
                return;
            }

            //Sort selected objects
            SortObjects();

            //Loop over each selected object and assign new name based on given naming convention
            for (int i = 0; i < indexSize; i++)
            {
                string finalName = string.Empty;

                //Checks digit precision
                String digits = "00";
                if (indexSize >= 99 || indexSize + startNumbering >= 99)
                {
                    digits = "000";
                }

                if (!string.IsNullOrEmpty(wantedPrefix))
                {
                    finalName += wantedPrefix;
                }

                if (!string.IsNullOrEmpty(wantedName))
                {
                    finalName += "_" + wantedName;
                }

                if (!string.IsNullOrEmpty(wantedSufix))
                {
                    finalName += "_" + wantedSufix;
                }

                if (allowNumbering)
                {

                    if (enumerateFromZero)
                    {

                        finalName += "_" + i.ToString(digits);
                    }
                    else
                    {
                        finalName += "_" + (startNumbering + i).ToString(digits);
                    }

                }

                selectedObjects[i].name = finalName;

            }

        }

        void SortObjects()
        {
            // Get selected objects in Hierarchy window
            // selectedObjects = Selection.gameObjects;

            // Sort selected objects by name
            selectedObjects = selectedObjects.OrderBy(x => x.name).ToArray();

            // Get parent object of first of the selected objects
            Transform parentObject = selectedObjects[0].transform.parent;

            // Loop over selected objects array and move each object based on sorted order
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                selectedObjects[i].transform.SetSiblingIndex(i);
            }
        }

    }
}
