using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Vector2 cubeRay = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);

            if (cubeHit) {
                // Debug.Log("We hit " + cubeHit.collider.name);
            }
        }
    }
}
