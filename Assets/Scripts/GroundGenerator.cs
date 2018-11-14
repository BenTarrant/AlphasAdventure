using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    public GameObject[] Platforms; // array of platforms
    public GameObject AveragePlatform; // supplies a reference for the average platform
    public Transform generationPoint; // where to spawn platform
    public float distanceBetween; // space between ( alter for drops of death)

    private float platformWidth; // reference to the width of platforms to avoid spawning on top of eachother

    // Use this for initialization
    void Start()
    {

        platformWidth = AveragePlatform.GetComponent<BoxCollider>().size.x;
        // use the box collider attached to each platform to specify the 'size' of platform

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        // if the position of generator is below point of generation.
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            // specifies the instatiate transform to platform width + specified distance
            Instantiate(Platforms[Random.Range(0, Platforms.Length)], transform.position, transform.rotation);
            // Instantiates a platform from array (to allow for expansion of platforms later) 
        }


    }
}
