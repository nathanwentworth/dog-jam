using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    float timeHeld = 0f;
    bool mouseDown = false;
    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }
    void Update() {

    }

    private void OnMouseDown() {
        mouseDown = true;
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
            timeHeld += Time.deltaTime;
            animator.SetBool("beingPet", true);
            Debug.Log("oh we draggin' " + timeHeld);
        }
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
