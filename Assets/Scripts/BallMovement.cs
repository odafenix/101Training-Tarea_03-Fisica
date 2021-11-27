using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float distanceToGround = 2f;
    public Transform BallTransform;
    public Transform StartingPoint;

    private float xInput;
    private float zInput;
    private bool grounded;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Saltar();
        CheckGrounded();
    }
    private void FixedUpdate()
    {
        Move();
        CheckAltitude();
        
    }
    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

    }
    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }
    private void Saltar()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            grounded = false;
        }
    }
    private void CheckGrounded()
    {

        RaycastHit hit;


        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround))
        {
            if(hit.collider.tag == "World")
            {
                Debug.DrawRay(transform.position, Vector3.down * distanceToGround, Color.green);
                grounded = true;
                Debug.Log("Estamos cerca del suelo");
            }
            else
            {
                Debug.DrawRay(transform.position, Vector3.down * distanceToGround, Color.red);
            }
        }
    }
    private void CheckAltitude(){
        if (BallTransform.position.y <= -50){
            BallTransform.position = StartingPoint.position;
        }
        else{
            return;
        }
    }
}
