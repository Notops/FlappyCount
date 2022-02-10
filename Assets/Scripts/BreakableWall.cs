using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BreakableWall : MonoBehaviour
{
    public GameObject oldObject;
    public GameObject newObject;
    public int amountToBreak;
    public float multiplicator;
    // Start is called before the first frame update

    public static event Action Win;

    private bool isColliding;

    private void Update()
    {
        isColliding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;

        if(other.tag == "Destroy")
        {
            Formation formation = FindObjectOfType<Formation>();
            
            if(formation.GetCurrentAmount() > amountToBreak)
            {
                oldObject.SetActive(false);
                newObject.SetActive(true);
            }
            else
            {
                Win();
                return;
            }
        }
    }
}
