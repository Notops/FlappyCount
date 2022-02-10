using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdMovement : MonoBehaviour
{
    public static float jumpForce = 10f;
    public GameObject startMenu;

    public static event Action StartGame;

    private static Rigidbody rb;
    private static float canJump;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        canJump = 0;
        //StartCoroutine(UntilStart());

        Detection.FinishEvent += FreezePozition;
        Formation.Lose += StopJumping;
    }

    private IEnumerator UntilStart()
    {
        
        yield return waitForKeyPress(KeyCode.Mouse0);
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) 
        {
            if (Input.GetKeyDown(key))
            {
                done = true;
                rb.useGravity = true;
                startMenu.SetActive(false);
                StartGame();
            }
            yield return null;
        }
        
       
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            rb.velocity = Vector3.up * jumpForce * canJump;
            
        }
    }

    private static void StopJumping()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, 0);
        canJump = 0;
    }

    private void FreezePozition()
    {

        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, 0);

        if(gameObject != null)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

        }


        transform.localPosition = new Vector3(0, 7.7f, transform.position.z);
    }

    public void StartLevel()
    {
        rb.useGravity = true;
        startMenu.SetActive(false);
        canJump = 1;
        rb.velocity = Vector3.up * jumpForce * canJump;
        StartGame();

    }

    private void OnDestroy()
    {
        Detection.FinishEvent -= FreezePozition;
    }


}
