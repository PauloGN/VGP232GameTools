using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TerrainStruct
{
    public int width = 256;
    public int height = 256;
    public int depth = 20;
    public float scale = 20f;
    public List<Texture2D> textures;
    public List<GameObject> vegetation;
    public int vegetationCount = 100;
}
