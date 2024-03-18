using UnityEngine;

/*
    This component is for all objects that the player can
    interact with such as enemies, items etc. It is meant
    to be used as a base class.
*/

public class Interactable : MonoBehaviour {

    public float radius = 3f;				// How close do we need to be to interact?
    public Transform interactionTransform;	// The transform from where we interact in case you want to offset it

    public Transform player;		// Reference to the player transform

    bool hasInteracted = false;	// Have we already interacted with the object?

    public virtual void Interact ()
    {
        // This method is meant to be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }

    void Update ()
    {
        // If we are currently being focused
        // and we haven't already interacted with the object
        if (!hasInteracted)
        {
            // If we are close enough
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                // Interact with the object
                if (Input.GetKey("e"))
                {
                    Interact();
                    hasInteracted = true;
                }
            }
        }
    }
    

}