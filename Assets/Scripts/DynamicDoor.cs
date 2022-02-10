using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDoor : MonoBehaviour
{

    public float topPos = 14f;
    public float lowPos = 3f;
    public float speed;

    private Rigidbody rb;
    private bool MoveUp = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      

        if (transform.position.y > topPos)
            MoveUp = false;
        if (transform.position.y < lowPos)
            MoveUp = true;

        if (MoveUp)
            rb.velocity = speed * new Vector3(0, 1, 0);
        else
            rb.velocity = speed * new Vector3(0, -1, 0);




    }
}
