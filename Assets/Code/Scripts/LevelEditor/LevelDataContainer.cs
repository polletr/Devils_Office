using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class LevelDataContainer : ScriptableObject
{
    public LevelData levelData = new LevelData();

#if UNITY_EDITOR
    private void OnValidate()
    {
        UnityEditor.EditorUtility.SetDirty(this); // Mark the object as dirty when changes are made
    }

    private void OnDisable()
    {
        UnityEditor.AssetDatabase.SaveAssets(); // Save the changes to disk when Unity disables the object
        Debug.Log("called");
    }
#endif

}

[System.Serializable]
public class LevelData
{
    public int levelWidth = 20;
    public int levelHeight = 20;

    public int[,] grid = new int[0, 0];
    public char[,] directions = new char[0, 0];


}
