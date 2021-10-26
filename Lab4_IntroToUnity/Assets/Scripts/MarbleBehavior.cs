using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 25f;
    public float jumpVelocity = 5f;

    private float fbInput;
    private float lrInput;

    private Rigidbody _rb;

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity,
                    ForceMode.Impulse);
        }
        /*this.transform.Translate(Vector3.forward * fbInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * lrInput * Time.deltaTime);*/
    }

    void FixedUpdate()
    {

        //Put code that moves the sprite using the RigidBody here
        Vector3 rotation = Vector3.up * lrInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position +
          this.transform.forward * fbInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

}
