using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("enter collision with " + other.gameObject);

        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            // want the player to be the child of the platform
            player.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("exit collision with " + other);
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            player.SetParent(null);
        }
    }
}
