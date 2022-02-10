﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using System;

public class Runner : MonoBehaviour
{
    [Header(" Components ")]
    //[SerializeField] private Animator animator;
    [SerializeField] private Collider collider;
    //[SerializeField] private Renderer renderer;
    public static int currentIndex;

    //[SerializeField] public Canvas gameOverCanvas; 
    private bool targeted;


    [Header(" Detection ")]
    [SerializeField] private LayerMask obstaclesLayer;




    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (!collider.enabled)
            return;

        DetectObstacles();
    }



    private void DetectObstacles()
    {
        if (Physics.OverlapSphere(transform.position, 0.5f, obstaclesLayer).Length > 0)
            Explode();
    }

    public void SetAsTarget()
    {
        targeted = true;
    }

    public bool IsTargeted()
    {
        return targeted;
    }

    public void Explode()
    {
        collider.enabled = false;
        //renderer.enabled = false;

        //if (transform.parent != null && transform.parent.childCount <= 1)

            //SceneManager.LoadScene("RookieUI");
        
        transform.parent = null;
        Destroy(gameObject);



    }




}
