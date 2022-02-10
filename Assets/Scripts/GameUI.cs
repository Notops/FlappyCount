using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI goldText;

    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SetLevelText();
        SetGoldText();
    }

    private void SetLevelText()
    {
        levelText.text = "Level " + gc.currentLevel;
    }

    private void SetGoldText()
    {
        goldText.text = gc.currentGold + "<sprite=22>";
    }
}
