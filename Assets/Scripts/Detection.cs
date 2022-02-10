using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Detection : MonoBehaviour
{
    [Header(" Managers ")]
    [SerializeField] private Formation squadFormation;
    [SerializeField] private Runner runner;
    [SerializeField] private GameObject runnersParent;

    [Header(" Settings ")]
    [SerializeField] private LayerMask doorLayer;
    [SerializeField] private LayerMask finishLayer;

    public static event Action FinishEvent; 





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetectDoors();
        DetectFinish();
    }
    
    private void DetectDoors()
    {
        Collider[] detectedDoors = Physics.OverlapSphere(transform.position, squadFormation.GetSquadRadius(), doorLayer);

        if (detectedDoors.Length <= 0) return;

        Collider collidedDoorCollider = detectedDoors[0];
        Door collidedDoor = collidedDoorCollider.GetComponentInParent<Door>();
       
        int runnersAmountToAdd = collidedDoor.GetRunnersAmountToAdd(collidedDoorCollider, runnersParent.transform.childCount);
        squadFormation.AddRunners(runnersAmountToAdd);
    }

    private void DetectFinish()
    {
        Collider[] detectedFinish = Physics.OverlapSphere(transform.position, squadFormation.GetSquadRadius(), finishLayer);


        if (detectedFinish.Length <= 0) return;
        FinishEvent();
    }

}


   