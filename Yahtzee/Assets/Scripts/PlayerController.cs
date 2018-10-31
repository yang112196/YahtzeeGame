using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    Vector3 movement;
    Animator anim;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FicedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
        rb.AddForce(movement);
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * 6f * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Animating(float h, float v)
    {
        bool walking = (h != 0) || (v != 0);
        anim.SetBool("IsWalking", walking);

    }
}
