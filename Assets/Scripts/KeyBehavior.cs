using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    public Transform followingTarget;
    public float smoothTime;
    private Vector2 vel;
    private bool isPickedUp = false;

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            transform.position = Vector2.SmoothDamp(transform.position, followingTarget.position, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
        }
    }
}
