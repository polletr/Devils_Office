using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelDataContainer : ScriptableObject
{
    public LevelData levelData = new LevelData();
}

[System.Serializable]
public class LevelData
{
    public int levelWidth = 20;
    public int levelHeight = 20;

    public int[,] grid = new int[0, 0];
    public char[,] directions = new char[0, 0];


}
