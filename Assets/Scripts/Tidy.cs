/*
Author: Kyle Peniston
Date: 10/10/2024
Description: The Tidy script is used to destroy the projectile after 5 seconds of its creation to save on memory.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tidy : MonoBehaviour
{
    void Start()
    {
        //Destory projectile after 5 seconds
        Destroy(gameObject, 5f);
    }
}
