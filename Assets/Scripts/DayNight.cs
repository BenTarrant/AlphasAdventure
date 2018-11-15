using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    // Scroll main texture based on time

    float scrollSpeed = 0.01f;
    float rotateSpeed = 0.2f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0.9f);
        transform.RotateAround(transform.position, transform.up, rotateSpeed);
    }
}
