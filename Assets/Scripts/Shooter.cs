/*
Author: Kyle Peniston
Date: 10/10/2024
Description: The Shooter script handles the movement of the camera, sets the boundary for the camera
and instantiates the projectile using the Fire1 button "Space".
*/
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Camera movement
    public float MoveFactor = 10f;

    //Projectile vars
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;

    //Boundaries for the camera
    public Vector3 minBounds;
    public Vector3 maxBounds;

    void Start()
    {
        //Camera boundaries
        minBounds = new Vector3(-6f, -0.5f, -10f);
        maxBounds = new Vector3(6f, 8f, 10f);
    }

    void Update()
    {
        //Camera controls
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * MoveFactor;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * MoveFactor;

        transform.Translate(new Vector3(h, v, 0));

        //Clamp the position to stay within bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minBounds.z, maxBounds.z);
        transform.position = clampedPosition;

        //Fire projectile
        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.AddForce(shotPos.forward * shotForce);

            //Set gameObject name for easy selection on collision
            shot.gameObject.name = "prop_samoflange";
        }
    }

}
