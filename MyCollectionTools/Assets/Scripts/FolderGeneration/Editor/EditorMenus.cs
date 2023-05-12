using UnityEngine;
using UnityEditor;


namespace FoxTools
{
    public class EditorMenus 
    {
        [MenuItem("FoxTools/Project/Project Setup Tool/Gererate Folders")]
        public static void InitProjectSetupTool()
        {
//            Debug.Log("Launcing Project Setup Tool!");
            ProjectSetup_window.InitWindow();
        }
    }
}
