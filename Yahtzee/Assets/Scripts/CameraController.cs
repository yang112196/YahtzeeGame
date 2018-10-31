using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public Transform lookAt;
    public Transform camTransofrm;

    private Camera cam;
    private float currX = 0.0f;
    private float currY = 0.0f;

    Vector3 offset;
	
    // Use this for initialization
	void Start () {
        camTransofrm = transform;
        offset = this.transform.position - player.transform.position;
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        currX += Input.GetAxis("Mouse X");
        currY += Input.GetAxis("Mouse Y");
    }

    private void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
        Vector3 dir = this.transform.position;
        Quaternion rotation = Quaternion.Euler(currY, currX, 0);
        camTransofrm.position = lookAt.position + rotation * dir;
    }
}
