using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if (collision.gameObject.name == "Marble")
       {
         Destroy(this.transform.gameObject);
       }
    }
}
