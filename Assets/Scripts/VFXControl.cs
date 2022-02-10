using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXControl : MonoBehaviour
{
    public GameObject VFXprefab;
    public Transform[] pivots;

    // Start is called before the first frame update
    void Start()
    {
        Detection.FinishEvent += EnableFireworks;
    }

    private void EnableFireworks()
    {
        GameObject obj = null;
        foreach (Transform x in pivots)
        {
            obj = Instantiate(VFXprefab, x);
        }
    }


}
