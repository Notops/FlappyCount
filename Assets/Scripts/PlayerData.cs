using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int gold;
    public int birdLevel;
    public int goldLevel;

    public PlayerData (SceneVariables data)
    {
        level = data.level;
        gold = data.gold;
        birdLevel = data.birdLevel;
        goldLevel = data.goldLevel;
    }
}
