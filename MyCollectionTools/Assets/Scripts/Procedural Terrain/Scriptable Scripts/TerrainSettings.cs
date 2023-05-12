using System.Collections.Generic;
using UnityEngine;


namespace FoxTools
{
    [CreateAssetMenu(fileName = "New Terrain Settings", menuName = "FoxTools/Terrain Settings")]
    public class TerrainSettings : ScriptableObject
    {
        public int width = 256;
        public int height = 256;
        public int depth = 20;
        public float scale = 20f;
        public List<Texture2D> textures;
        public List<GameObject> vegetation;
        public int vegetationCount = 100;
    }
}
