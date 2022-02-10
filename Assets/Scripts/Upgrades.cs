using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{

    public Formation formation;
    public GameController gc;

    public TextMeshProUGUI birdText;
    public TextMeshProUGUI goldText;

    public TextMeshProUGUI birdUpgradeText;
    public TextMeshProUGUI goldUpgradeText;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        
        formation.AddRunners(gc.currentBirdLevel);
        SetText();
    }

    void Update()
    {
        
    }

    public void BirdLevelUp()
    {
        if( gc.currentGold > (gc.currentBirdLevel + 1) * 100)
        {
            gc.currentGold -= (gc.currentBirdLevel + 1) * 100;
            gc.currentBirdLevel++;
            SetText();
            formation.AddRunners(1);
        }
    }

    public void GoldLevelUp()
    {
        if (gc.currentGold > (gc.currentGoldLevel + 1) * 100)
        {
            gc.currentGold -= (gc.currentGoldLevel + 1) * 100;
            gc.currentGoldLevel++;
            SetText();
        }   
    }

    public void SetText()
    {
        birdText.text = "Level " + gc.currentBirdLevel;
        goldText.text = "Level " + gc.currentGoldLevel;

        birdUpgradeText.text = "" + ((gc.currentBirdLevel + 1) * 100);
        goldUpgradeText.text = "" + ((gc.currentGoldLevel + 1) * 100);
    }
}
