using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private bool isLocked = true;
    public Sprite unlockedDoor;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(isLocked);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("key"))
        {
            isLocked = false;
            spriteRenderer.sprite = unlockedDoor;
            other.gameObject.SetActive(false);
        }
    }
}
