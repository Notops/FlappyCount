using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public GameObject[] levelPrefabs;
    public int[] levelRewards;
    public GameObject levelParent;

    public int currentLevel;
    public int currentGold;
    public int currentBirdLevel;
    public int currentGoldLevel;

    private static SceneVariables data;

    private void Awake()
    {
        data = FindObjectOfType<SceneVariables>();
        data.LoadVariables();
        currentLevel = data.level;
        currentGold = data.gold;
        currentBirdLevel = data.birdLevel;
        currentGoldLevel = data.goldLevel;
    }

    void Start()
    {
        BreakableWall.Win += LevelReward;
        GameObject obj = Instantiate(levelPrefabs[currentLevel], levelParent.transform.position, Quaternion.identity, levelParent.transform);
    }

    void Update()
    {
        
    }

    public void SaveProgress()
    {
        data.level = currentLevel;
        data.gold = currentGold;
        data.birdLevel = currentBirdLevel;
        data.goldLevel = currentGoldLevel;
        data.SaveVariables();
    }

    public void NextLevel()
    {
        currentLevel++;
        SaveProgress();
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void Retry()
    {
        SaveProgress();
        SceneManager.LoadScene("Scenes/SampleScene");   
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
    }

    public int RemoveGold(int amount)
    {
        if (currentGold > amount)
        {
            currentGold -= amount;
            return 0;
        }
        else
            return -1;
    }

    private void LevelReward()
    {
        Debug.Log("Added Gold = " + levelRewards[currentLevel]);
        AddGold(levelRewards[currentLevel]);
    }
}
