using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 25f;
    public float jumpVelocity = 5f;


    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;

    public GameObject blast;
    public float blastSpeed = 100f;

    private float fbInput;
    private float lrInput;

    private Rigidbody _rb;

    private SphereCollider _col;

    public GameBehavior gameManager;
    

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
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
 
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.LogFormat("Space bar pressed");
             _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
                
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBlast = Instantiate(blast,
                this.transform.position + new Vector3(1, 0, 0),
                    this.transform.rotation) as GameObject;
        
            Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();
        
            blastRB.velocity = this.transform.forward *
            blastSpeed;
            }
    }

    private bool IsGrounded()
    {
        bool grounded = Physics.CheckSphere(this.transform.position,
             distanceToGround + 0.5f, groundLayer,
                QueryTriggerInteraction.Ignore);

        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if (collision.gameObject.name == "Obstacle")
       {
         gameManager.Health -= 1;
       }
       //Put collision code here
       if (collision.gameObject.name == "PowerUp")
       {
         gameManager.Health += 1;
       }
    }
        

}

