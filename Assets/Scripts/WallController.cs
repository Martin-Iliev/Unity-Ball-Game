using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Canvas TextController;
    [SerializeField]
    AudioSource wallBreak;

    Rigidbody[] components;

    private bool willMove = false;
    private bool isBroken = false;

    void Start()
    {
        components = this.GetComponentsInChildren<Rigidbody>();
        
        foreach (Rigidbody cube in components)
        {
           cube.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY;
        }
    }

    public void UnFreeze()
    {
        if (willMove)
        {
            foreach (Rigidbody cube in components)
            {
                cube.constraints = RigidbodyConstraints.None;
            }
            if (!isBroken)
            {
                TextController.GetComponent<TextController>().DisplayTextTimer("Wall broken!", 3);
                wallBreak.Play();
                isBroken = true;
            }
        }
    }

    private void FixedUpdate()
    {
        willMove = player.GetComponent<PlayerScaler>().isBig;
    }
}
