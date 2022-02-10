using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Formation : MonoBehaviour
{
    [Header(" Components ")]
    [SerializeField] private TextMeshPro squadAmountText;
    [SerializeField] private int amountAtStart = 1;
    [SerializeField] private int currentAmount;

    [Header(" Formation Settings ")]
    [Range(0f, 1f)]
    [SerializeField] private float radiusFactor;
    [Range(0f, 1f)]
    [SerializeField] private float angleFactor;

    [Header(" Settings ")]
    [SerializeField] private Runner runnerPrefab;

    public static event Action Lose;

    private bool final = false;

    // Start is called before the first frame update
    void Start()
    {
        currentAmount = amountAtStart;
        Detection.FinishEvent += SetFinal;
    }

    // Update is called once per frame
    void Update()
    {
        if (!final)
            FermatSpiralPlacement();
        else
            FinishPlacement();
        
        SetCurrentAmount();
    }

    private void FermatSpiralPlacement()
    {
        float goldenAngle = 137.5f * angleFactor;
        int max = transform.childCount;


        for (int i = 0; i < transform.childCount; i++)
        {
            float x = -radiusFactor * Mathf.Sqrt(i + 1) * (float)Math.Tanh(Mathf.Deg2Rad * goldenAngle * (i + 1));
            float z = radiusFactor * Mathf.Sqrt(i + 1) * Mathf.Sin(Mathf.Deg2Rad * goldenAngle * (i + 1));
            float y = radiusFactor * Mathf.Sqrt(i + 1) * Mathf.Cos(Mathf.Deg2Rad * goldenAngle * (i + 1));
            //float z = 0;

            Vector3 runnerLocalPosition = new Vector3(x, y, z);
            transform.GetChild(i).localPosition = Vector3.Lerp(transform.GetChild(i).localPosition, runnerLocalPosition, 0.1f);
        }
    }

    public float GetSquadRadius()
    {
        return radiusFactor * Mathf.Sqrt(transform.childCount);
    }

    public void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Runner runnerInstance = Instantiate(runnerPrefab, transform);

            runnerInstance.name = "Bird_" + runnerInstance.transform.GetSiblingIndex();
        }
        
    }

    public void SetCurrentAmount()
    {
        currentAmount = GetCurrentAmount();

        squadAmountText.text = "" + currentAmount;

        if( currentAmount == 0)
        {
            Lose();
        }
    }
    
    public int GetCurrentAmount()
    {
        return transform.childCount;
    }

    private void FinishPlacement()
    {
        int max = transform.childCount;


        for (int i = 0; i < transform.childCount; i++)
        {
            float x = radiusFactor * Mathf.Sqrt(i + 1) * Mathf.Cos(Mathf.Deg2Rad * (i + 1)) * Mathf.Pow(-1f, i);
            float z = 0;
            float y = 0;
            //float z = 0;

            Vector3 runnerLocalPosition = new Vector3(x, y, z);
            transform.GetChild(i).localPosition = Vector3.Lerp(transform.GetChild(i).localPosition, runnerLocalPosition, 0.1f);
        }
    }

    private void SetFinal()
    {
        final = true;

    }
}
