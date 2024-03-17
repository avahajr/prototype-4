using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorBehavior : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private bool isLocked = true;
    public Sprite unlockedDoor;
    public float transitionTime = 1f;

    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("key"))
        {
            isLocked = false;
            spriteRenderer.sprite = unlockedDoor;
            other.gameObject.SetActive(false);
        }


        if (other.gameObject.CompareTag("Player") && !isLocked)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
