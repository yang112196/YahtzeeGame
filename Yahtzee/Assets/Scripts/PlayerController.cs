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
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(0f,0f,h);
        transform.Rotate(0f,v,0f);

        if(h != 0){
            anim.SetBool("IsWalking", true);
        }
        else{
            anim.SetBool("IsWalking", false);
        }
    }

    
}
