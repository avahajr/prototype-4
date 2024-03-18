using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorBehavior : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private bool isLocked = true;
    public Sprite unlockedDoor;
    public float transitionTime = 1f;


    private void FixedUpdate()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision with " +other);
        
        if (other.gameObject.CompareTag("key"))
        {
            isLocked = false;
            spriteRenderer.sprite = unlockedDoor;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && Input.GetAxis("Vertical") > 0 && !isLocked)
        {
            Debug.Log("loading next level");
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
