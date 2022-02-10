using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [Header(" Bonuses ")]
    [SerializeField] private bool randomBonuses;
    [SerializeField] private Bonus topBonus;
    [SerializeField] private Bonus midBonus;
    [SerializeField] private Bonus botBonus;

    [Header(" Components ")]
    [SerializeField] private Collider[] doorsColliders;
    [SerializeField] private TextMeshPro topDoorText;
    [SerializeField] private TextMeshPro midDoorText;
    [SerializeField] private TextMeshPro botDoorText;


    // Start is called before the first frame update
    void Start()
    {
        if (randomBonuses)
            SetRandomBonuses();

        ConfigureBonusTexts();
    }

    private void SetRandomBonuses()
    {
        topBonus = BonusUtils.GetRandomBonus();
        if( doorsColliders.Length > 1)
        {
            midBonus = BonusUtils.GetRandomBonus();
            botBonus = BonusUtils.GetRandomBonus();
        }
    }

    private void ConfigureBonusTexts()
    {
        topDoorText.text = BonusUtils.GetBonusString(topBonus);
        if (doorsColliders.Length > 1)
        {
            midDoorText.text = BonusUtils.GetBonusString(midBonus);
            botDoorText.text = BonusUtils.GetBonusString(botBonus);
        }
    }

    public int GetRunnersAmountToAdd(Collider collidedDoor, int currentRunnersAmount)
    {
        DisableDoors();

        Bonus bonus;

        if( doorsColliders.Length <= 1)
        {
            bonus = topBonus;
            return BonusUtils.GetRunnersAmountToAdd(currentRunnersAmount, bonus);
        }

        if (collidedDoor.transform.name == "Top Door")
            bonus = topBonus;
        else if (collidedDoor.transform.name == "Mid Door")
            bonus = midBonus;
        else
            bonus = botBonus;

        return BonusUtils.GetRunnersAmountToAdd(currentRunnersAmount, bonus);
    }

    private void DisableDoors()
    {
        foreach (Collider c in doorsColliders)
            c.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
