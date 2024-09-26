using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 2;
    public float Force;
    public Animator anim;
    public float smoothTime;
    float smoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, y).normalized;

        if(direction.magnitude >= 0.1f) {
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
            characterController.Move(direction * Force * Time.deltaTime);
        }


        if(Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", false);
        }
        //characterController.Move(move);
        //if (move.x == 0 && move.z == 0)
        //{
        //    anim.SetBool("walk", false);
        //}
        //else
        //{
        //    anim.SetBool("walk", true);
        //}
    }
}
