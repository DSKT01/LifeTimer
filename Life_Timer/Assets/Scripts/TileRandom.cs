/*
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileRandom : Tile  {

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Sprite previw;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = sprites[Random.Range(0,sprites.Length)];
        tileData.colliderType = ColliderType.Grid;
    }


#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/RandomTile")]
    public static void CreateRandomTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save RandomTile", "New RandomTile", "asset", "Save randomtile", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TileRandom>(), path);
    }

#endif

}
*/