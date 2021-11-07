using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private int _obsHealth = 10;
    public int ObsHealth
    {
        get { return _obsHealth; }
        set {
            _obsHealth = value;
            Debug.LogFormat("Obstacle Health: {0}", _obsHealth);
        }
    }

    void Start()
    {
      
    }

    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if (collision.gameObject.name == "Blast" )
       {
           if(ObsHealth == 1){
                Destroy(this.transform.gameObject);
           }
           else {
            ObsHealth -= 1;
           }
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
