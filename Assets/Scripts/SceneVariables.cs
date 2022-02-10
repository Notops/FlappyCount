using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVariables : MonoBehaviour
{
    public int gold = 0;
    public int level = 0;
    public int birdLevel = 0;
    public int goldLevel = 0;
    



    private void Start()
    {
        
    }

    public void SaveVariables()
    {
        SaveData.SavePlayer(this);
    }

    public void LoadVariables()
    {    
        PlayerData data = SaveData.LoadPlayer(this);

        level = data.level;
        gold = data.gold;
        birdLevel = data.birdLevel;
        goldLevel = data.goldLevel;
    }
}
