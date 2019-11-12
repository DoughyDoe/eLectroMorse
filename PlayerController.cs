using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public bool useController;


    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        moveVelocity = moveInput * moveSpeed;
        if (!useController)
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.right, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
                transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, transform.position.z));
            }
        }


    }


    void FixedUpdate()
    {
        myRigidBody.velocity = moveVelocity;
    }
}
