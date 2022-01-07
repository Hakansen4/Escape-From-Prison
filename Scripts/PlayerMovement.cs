using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float Speed = 12f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 3f;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private checkpointController cp;
    private void Awake()
    {
        cp = GameObject.FindGameObjectWithTag("cpC").GetComponent<checkpointController>();
    }
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * x + transform.forward * z;
        controller.Move(Move * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cp1"))
        {
            cp.setPoint1();
        }
        else if (other.gameObject.CompareTag("cp2"))
        {
            cp.setPoint2();
        }
        else if (other.gameObject.CompareTag("cp3"))
        {
            cp.setPoint3();
        }
        else if(other.gameObject.CompareTag("end"))
        {
            cp.end();
        }
    }
}
