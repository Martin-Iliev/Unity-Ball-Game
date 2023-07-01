using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    public float scaleAmount = 0.1f;
    public float massMultiplier = 2f;
    [SerializeField]
    Canvas TextController;

    private Rigidbody rb;
    private Vector3 initialScale;
    private float initialMass;
    [HideInInspector]
    public bool isBig = false;
    [HideInInspector]
    public bool isSmall = false;

    [SerializeField]
    AudioSource ballBig;
    [SerializeField]
    AudioSource ballSmall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //saving "normal" ball
        initialScale = transform.localScale;
        initialMass = rb.mass;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Big();
            ballBig.Play();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Small();
            ballSmall.Play();
        }
        SizeUI();
    }

    private void Big()
    {
        if (isBig || isSmall)
        {
            transform.localScale = initialScale;
            rb.mass = initialMass;
            isBig = false;
            isSmall = false;
        }
        else
        {
            transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount) * 1.5f;
            rb.mass = initialMass * massMultiplier * 2f;

            isBig = true;
        }
    }

    private void Small()
    {
        if (isSmall || isBig)
        {
            transform.localScale = initialScale;
            rb.mass = initialMass;
            isSmall = false;
            isBig = false;
        }
        else
        {
            transform.localScale -= new Vector3(scaleAmount, scaleAmount, scaleAmount) / 4;
            rb.mass = initialMass / massMultiplier;
            isSmall = true;
        }
    }

    private void SizeUI()
    {
        if (isSmall)
        {
            TextController.GetComponent<TextController>().DisplayText("Player size: Small");
        }
        if (isBig)
        {
            TextController.GetComponent<TextController>().DisplayText("Player size: Big");
        }
        if (!isSmall && !isBig)
        {
            TextController.GetComponent<TextController>().DisplayText("Player size: Default");
        }
    }
}