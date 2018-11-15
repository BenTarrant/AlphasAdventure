using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

    void Start()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 8);
    }
}
