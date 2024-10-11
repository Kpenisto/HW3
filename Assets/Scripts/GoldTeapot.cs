/*
Author: Kyle Peniston
Date: 10/10/2024
Description: GoldTeapot handles the movement of the "Twist" teapot. The teapot moves in a horizontal oscillating motion

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTeapot : MonoBehaviour
{
    //Gold teapot vars
    public float speed = 3f;
    public float distance = 10f;
    private Vector3 startPosition;

    public GameObject goldTeapot;
    private Rigidbody goldTeaPotRb;

    void Start()
    {
        //Find starting position and rb
        startPosition = transform.position;
        goldTeaPotRb = goldTeapot.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Oscillate back and forth between two bounds
        float oscillation = Mathf.Sin(Time.time * speed) * distance / 2;
        transform.position = new Vector3(startPosition.x + oscillation, startPosition.y, startPosition.z);
    }
}
