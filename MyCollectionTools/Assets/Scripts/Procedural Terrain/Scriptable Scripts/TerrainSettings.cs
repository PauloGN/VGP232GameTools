using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Terrain Settings", menuName = "Terrain Settings")]
public class TerrainSettings : ScriptableObject
{
    public int width = 256;
    public int height = 256;
    public int depth = 20;
    public float scale = 20f;
    public List<Texture2D> textures;
    public List<GameObject> vegetation;
    public int vegetationCount = 100;


    public void ClearAndRegenerateTerrain()
    {
        // Reset all terrain settings to their default values
        width = 256;
        height = 256;
        depth = 20;
        scale = 20f;
        textures = new List<Texture2D>();
        vegetation = new List<GameObject>();
        vegetationCount = 100;
    }

}