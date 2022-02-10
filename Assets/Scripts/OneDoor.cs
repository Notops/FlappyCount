using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OneDoor : Door
{
    [Header(" Bonuses ")]
    [SerializeField] private bool randomBonuses;
    [SerializeField] private Bonus midBonus;

    [Header(" Components ")]
    [SerializeField] private Collider[] doorsColliders;
    [SerializeField] private TextMeshPro midDoorText;


    // Start is called before the first frame update
    void Start()
    {
        if (randomBonuses)
            SetRandomBonuses();

        ConfigureBonusTexts();
    }

    private void SetRandomBonuses()
    {
        midBonus = BonusUtils.GetRandomBonus();
    }

    private void ConfigureBonusTexts()
    {
        midDoorText.text = BonusUtils.GetBonusString(midBonus);
    }

    public int GetRunnersAmountToAdd(Collider collidedDoor, int currentRunnersAmount)
    {
        DisableDoors();

        Bonus bonus;

        bonus = midBonus;

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
