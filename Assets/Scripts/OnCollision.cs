/*
Author: Kyle Peniston
Date: 10/10/2024
Description: The OnCollision script is used to handle the collision event. Gravity on the teapots is added, rotation stopped,
teapot counter is incremented on the UIScript, teapot is destroyed after 2 seconds to save on memory.

OnTriggerEnter function is used to handle the gold teapot trigger event. We destroy the gold teapot on hit, then shrink the
Pickup teapots to 35% of thier size.
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public GameObject teapot;
    private Rigidbody teaPotRb;


    private void Start()
    {
        teaPotRb = teapot.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision Enter");
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("Collision Stay");
    }

    private void OnCollisionExit(Collision collision)
    {
        //If collision happens, turn on gravity on teaPot object.
        teaPotRb.useGravity = true;

        //Stop rotation
        teaPotRb.angularVelocity = Vector3.zero;

        //Only count collisions with samoflange
        if (collision.gameObject.name == "prop_samoflange")
        {
            FindObjectOfType<UIScript>().OnTeapotHit();
            Destroy(teapot, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy Gold TeaPot on hit
        Destroy(teapot);
        
        //Change the size of all other teapots
        GameObject[] teapots = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject teapot in teapots)
        {
            teapot.transform.localScale *= 0.35f;
        }
    }
}