using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuLogic : MonoBehaviour
{

    private static GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = transform.gameObject;
        //obj.SetActive(false);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static void EnableStartMenu()
    {
        obj.SetActive(true);
    }
}
