using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    Vector3 movement;
    Animator anim;
    public float moveSpeed = 1f;
    public float rotationRate;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        rotationRate = 360;  
    }
	
	// Update is called once per frame
	void Update () {
        float turn = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");
        Move(move);
        Turn(turn);

        if(move != 0){
            anim.SetBool("IsWalking", true);
        }
        else{
            anim.SetBool("IsWalking", false);
        }
    }

    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
        //rb.AddForce(transform.forward * input * moveSpeed, ForceMode.Force);
       
    }

    private void Turn(float input){
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }


}
