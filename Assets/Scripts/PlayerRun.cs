using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerRun : MonoBehaviour
{
 
   [SerializeField] private float moveSpeed ;
    [SerializeField] private float rotationSpeed ;
    [SerializeField] private float jumpForce;

    private Rigidbody rb;
    private Animator anim;
    public bool isGrounded;

    //private void OnCollisionEnter()
    //{
    //    anim.SetBool("grounded", false);
    //    isGrounded = true;
    //}

    void Start()
    {
       rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            Debug.Log("dsfg");

            jumpForce = 2000;
            //rb.AddForce(new Vector3(0,jumpForce,0));
            rb.AddForce(Vector3.up * moveSpeed, ForceMode.VelocityChange);
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //anim.SetBool("grounded", true);
            //isGrounded = false;
            anim.SetTrigger("jump");

            //ground = false;
            //jumpSFX.Play();
        }

        if (moveInput.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(moveInput);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
      anim.SetBool("walk" , moveInput.magnitude > 0.1f);

        rb.velocity = moveInput * moveSpeed;
    }

    
}
