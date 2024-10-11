/*
Author: Kyle Peniston
Date: 10/10/2024
Description: RotatorScript handles the rotation of the teapots.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    void Update()
    {
        //Rotate teapots
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
    }
}
