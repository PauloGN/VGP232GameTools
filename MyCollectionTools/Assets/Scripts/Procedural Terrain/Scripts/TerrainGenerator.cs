using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;
using System.Linq;

namespace FoxTools
{
    [ExecuteInEditMode]
    public class TerrainGenerator : MonoBehaviour
    {
        public TerrainSettings terrainSettings;
        public event Action vegetationGenerated;
        private readonly int padding = 1;

        [SerializeField] TerrainStruct upDateTerrainData;

        public TerrainData GenerateTerrain()
        {
            TerrainData terrainData = new TerrainData();
            float[,] heights = GenerateHeights();
            terrainData.heightmapResolution = terrainSettings.width + padding;
            terrainData.SetHeights(0, 0, heights);
            AddTextures(terrainData);
            terrainData.size = new Vector3(terrainSettings.width, terrainSettings.depth, terrainSettings.height);
            GetComponent<Terrain>().terrainData = terrainData;
            AddVegetation(terrainData);

            return terrainData;
        }

        private float[,] GenerateHeights()
        {
            float[,] heights = new float[terrainSettings.width + padding, terrainSettings.height + padding];
            for (int x = 0; x < terrainSettings.width; x++)
            {
                for (int y = 0; y < terrainSettings.height; y++)
                {
                    heights[x, y] = CalculateHeight(x, y);
                }
            }
            return heights;
        }

        private float CalculateHeight(int x, int y) => Mathf.PerlinNoise((float)x / terrainSettings.width * terrainSettings.scale, (float)y / terrainSettings.height * terrainSettings.scale);

        private void AddTextures(TerrainData terrainData)
        {
            TerrainLayer[] terrainLayers = terrainSettings.textures.ConvertAll(texture => new TerrainLayer
            {
                diffuseTexture = texture,
                tileSize = new Vector2(15, 15),
            }).ToArray();
            terrainData.terrainLayers = terrainLayers;
            float[,,] alphaMap = GenerateAlphaMap();
            terrainData.SetAlphamaps(0, 0, alphaMap);
        }

        private float[,,] GenerateAlphaMap()
        {
            float[,,] alphaMap = new float[terrainSettings.width, terrainSettings.height, terrainSettings.textures.Count];
            for (int x = 0; x < terrainSettings.width; x++)
            {
                for (int y = 0; y < terrainSettings.height; y++)
                {
                    for (int i = 0; i < terrainSettings.textures.Count; i++)
                    {
                        alphaMap[x, y, i] = CalculateAlpha(x, y, i);
                    }
                }
            }
            return alphaMap;
        }

        private float CalculateAlpha(int x, int y, int textureIndex) => CalculateHeight(x, y) >= textureIndex / (float)terrainSettings.textures.Count ? 1f : 0f;

        public void RemoveVegetation()
        {
            Transform[] vegetationChildren = transform.Cast<Transform>().Where(t => t.CompareTag("Vegetation")).ToArray();
            foreach (Transform child in vegetationChildren)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        private void AddVegetation(TerrainData terrainData)
        {
            int vegetationCount = terrainSettings.vegetation.Count;

            for (int i = 0; i < terrainSettings.vegetationCount; i++)
            {
                int vegetationIndex = UnityEngine.Random.Range(0, vegetationCount);
                float x = UnityEngine.Random.Range(0f, terrainSettings.width);
                float z = UnityEngine.Random.Range(0f, terrainSettings.height);
                float y = terrainData.GetInterpolatedHeight(x / terrainSettings.width, z / terrainSettings.height);
                Vector3 position = transform.position + new Vector3(x, y, z);
                RaycastHit hit;

                if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
                {
                    // position = hit.point;
                    position.y += terrainSettings.vegetation[vegetationIndex].transform.position.y;
                    Instantiate(terrainSettings.vegetation[vegetationIndex],
                    position, Quaternion.identity, transform).tag = "Vegetation";
                }
            }
            OnVegetationGenerated();
        }

        public void UpdateData()
        {
            if (upDateTerrainData.width >= 0)
            {
                terrainSettings.width = upDateTerrainData.width;
            }

            if (upDateTerrainData.height >= 0)
            {
                terrainSettings.height = upDateTerrainData.height;
            }

            if (upDateTerrainData.depth >= 0)
            {
                terrainSettings.depth = upDateTerrainData.depth;
            }

            if (upDateTerrainData.scale >= 0)
            {
                terrainSettings.scale = upDateTerrainData.scale;
            }

            if (upDateTerrainData.textures != null && upDateTerrainData.textures.Count > 0)
            {
                terrainSettings.textures = upDateTerrainData.textures;
            }

            if (upDateTerrainData.vegetation != null && upDateTerrainData.vegetation.Count > 0)
            {
                terrainSettings.vegetation = upDateTerrainData.vegetation;
            }

            if (upDateTerrainData.vegetationCount >= 0)
            {
                terrainSettings.vegetationCount = upDateTerrainData.vegetationCount;
            }

            Debug.Log("Data updated at the scriptable object: " + terrainSettings.name);
        }

        private void OnVegetationGenerated()
        {
            vegetationGenerated?.Invoke();
        }
    }

    [CustomEditor(typeof(TerrainGenerator))]
    public class TerrainGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            TerrainGenerator terrainGenerator = (TerrainGenerator)target;
            if (GUILayout.Button("Regenerate Terrain again"))
            {
                terrainGenerator.RemoveVegetation();
                terrainGenerator.GenerateTerrain();
            }

            if (GUILayout.Button("Update Data"))
            {
                terrainGenerator.UpdateData();
            }

        }
    }
}

