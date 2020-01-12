using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    float timeHeld = 0f;
    bool mouseDown = false;
    Animator animator;

    Vector3 destination;

    void Start() {
        animator = GetComponent<Animator>();
        transform.position = GameManager.Instance.RandomInitialSpawn();
    }
    void Update() {

        float destinationDistance = Vector2.Distance(transform.position, destination);
        if (destinationDistance > 1f) {
            transform.position = Vector2.MoveTowards(transform.position, destination, 0.01f);
            // Debug.Log("moving towards destination, distance remaining: " + destinationDistance);
        } else {
            destination = GameManager.Instance.RandomDestination();
            // Debug.Log("destination reached, new destination: " + destination);
        }


        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    private void OnMouseDown() {
        mouseDown = true;
        IncreasePoints(1f);
    }

    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button.
    /// </summary>
    void OnMouseUp() {
        mouseDown = false;
        animator.SetBool("beingPet", false);
    }

    /// <summary>
    /// OnMouseDrag is called when the user has clicked on a GUIElement or Collider
    /// and is still holding down the mouse.
    /// </summary>
    void OnMouseOver() {
        if (mouseDown) {
            IncreasePoints(Time.deltaTime);
            animator.SetBool("beingPet", true);
            Debug.Log("oh we draggin' " + timeHeld);
        }
    }

    void IncreasePoints(float amount) {
        timeHeld += amount;
        GameManager.Instance.IncreaseHeldTime(amount);

    }

    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    void OnMouseExit() {
    // maybe we won't need this? currently will disable the dragging when it leaves the collider. dunno if that will feel great of if it'll be too unforgiving
        animator.SetBool("beingPet", false);
        mouseDown = false;
    }
}
