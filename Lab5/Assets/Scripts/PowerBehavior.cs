using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if (collision.gameObject.name == "Marble")
       {
         Destroy(this.transform.gameObject);
       }
    }
}

