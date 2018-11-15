using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float camMoveSpeed;
    private Rigidbody Rb; // private reference for Rigidbody


    void Start () {

        Rb = GetComponent<Rigidbody>(); // fetch the rigidbody attached to this GO
        

    }


    void Update () {
        //camMoveSpeed = GameObject.Find("Player").GetComponent<PlayerController>().moveSpeed; 
        //set's the camMoveSpeed float to be the moveSpeed value found in the PlayerController
        //This is supposed to match their speed, allowing one to effect the other
        //DOESN'T WORK AS INTENDED - Currently Alpha seems to move slightly slower than the camera
        //and will progressively edge off screen as you play for longer
        Rb.velocity = new Vector2(camMoveSpeed, Rb.velocity.y); 
        // adds velocity along the x axis at the camMoveSpeed value
    }
}
