using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehavior : MonoBehaviour
{
    public float onscreenDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
