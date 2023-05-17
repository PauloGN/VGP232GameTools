using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;


namespace FoxTools
{
    public class ProjectSetup_window : EditorWindow 
    {
        #region Variables
        static ProjectSetup_window win;

        private string gameName = "Game";
        #endregion




        #region Main Methods
        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetup_window>("Project Setup");
            win.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            gameName = EditorGUILayout.TextField("Game Name: ", gameName);
            EditorGUILayout.EndHorizontal();

            if(GUILayout.Button("Create Project Structure", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                CreateProjectFolders();
            }

            if(win != null)
            {
                win.Repaint();
            }
        }
        #endregion


        #region Custom Methods
        void CreateProjectFolders()
        {
            //Check the User Input
            if(string.IsNullOrEmpty(gameName))
            {
                return;
            }

            if(gameName == "Game")
            {
                if(!EditorUtility.DisplayDialog("Project Setup Warning", "Do your really want to call yoru project Game?", "Yes", "No"))
                {
                    CloseWindow();
                    return;
                }
            }

            //Create Root Folder
            string assetPath = Application.dataPath;
            string rootPath = assetPath + "/" + gameName;
            DirectoryInfo rootInfo = Directory.CreateDirectory(rootPath);


            //Create sub Directories
            if(!rootInfo.Exists)
            {
                return;
            }
            CreateSubFolders(rootPath);

            AssetDatabase.Refresh();
            CloseWindow();
        }


        void CreateSubFolders(string rootPath)
        {
            DirectoryInfo rootInfo = null;
            List<string> folderNames = new List<string>();

            rootInfo = Directory.CreateDirectory(rootPath + "/Art");
            if(rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Animation");
                folderNames.Add("Objects");
                folderNames.Add("Materials");
                folderNames.Add("Prefabs");

                CreateFolders(rootPath + "/Art", folderNames);
            }


            rootInfo = Directory.CreateDirectory(rootPath + "/" + "Code");
            if(rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Editor");
                folderNames.Add("Scripts");
                folderNames.Add("Shaders");

                CreateFolders(rootPath + "/" + "Code", folderNames);
            }

            rootInfo = Directory.CreateDirectory(rootPath + "/" + "Resources");
            if(rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Characters");
                folderNames.Add("Managers");
                folderNames.Add("Props");
                folderNames.Add("UI");

                CreateFolders(rootPath + "/" + "Resources", folderNames);
            }

            rootInfo = Directory.CreateDirectory(rootPath + "/" + "Prefabs");
            if(rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Characters");
                folderNames.Add("Props");
                folderNames.Add("UI");

                CreateFolders(rootPath + "/Prefabs", folderNames);

            }

            //Create Scenes
            DirectoryInfo sceneInfo = Directory.CreateDirectory(rootPath + "/Scenes");
            if(sceneInfo.Exists)
            {
                CreateScene(rootPath + "/Scenes", gameName + "_Main");
                CreateScene(rootPath + "/Scenes", gameName + "_Frontend");
                CreateScene(rootPath + "/Scenes", gameName + "_Startup");
            }
        }


        void CreateFolders(string aPath, List<string> folders)
        {
            foreach(string folder in folders)
            {
                Directory.CreateDirectory(aPath + "/" + folder);
            }
        }

        void CreateScene(string aPath, string aName)
        {
            Scene curScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(curScene, aPath + "/" + aName + ".unity", true);
        }

        void CloseWindow()
        {
            if(win)
            {
                win.Close();
            } 
        }
        #endregion
    }
}
