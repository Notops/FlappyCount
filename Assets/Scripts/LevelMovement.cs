using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float canMove;

    public float levelspeed = 20f;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        StopMoving();
        rb = GetComponent<Rigidbody>();
        BirdMovement.StartGame += StartMoving;
        Detection.FinishEvent += FinalBoost;
        Formation.Lose += StopMoving;
        BreakableWall.Win += StopMoving;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = levelspeed * direction * canMove;
    }

    private void StopMoving()
    {
        canMove = 0;
        Debug.Log("Stopped");
    }

    private void StartMoving()
    {
        canMove = 1;
    }

    private void FinalBoost()
    {
        canMove = 3;
    }
}
