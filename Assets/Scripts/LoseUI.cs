using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseUI : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        Formation.Lose += SetUIActive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUIActive()
    {
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }
}
