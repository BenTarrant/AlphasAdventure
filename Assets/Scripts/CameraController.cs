using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player; // public reference for the player in inspector


    void LateUpdate() // late update becuase tracsk objects that move during update
    {
        transform.position = new Vector3(player.transform.position.x + 6f, 2f, -10f); // ensures the cameras position
        //is wherever the player is plus and minus certain offsets to ensure desired position
        //also enables player speed to raise over time without altering camera performance/ position
    }

}
