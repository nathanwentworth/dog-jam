using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private float totalHeldTime;
    public float TotalHeldTime {
        get { return totalHeldTime; }
        private set {
            totalHeldTime = value;
            UpdateHud();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void UpdateHud() {

    }

}
