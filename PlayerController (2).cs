/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //
    
    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;
    public GunController theGun;

    public bool useController=false;
    //public GameObject shield;

    

    private void Awake()
    {
        
        foreach (string s in Input.GetJoystickNames())
        {
            if (s.Length != 0)
            {
                useController = true;
                //numPlayers++;
            }
        }
        

    }

    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        

        //shield.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        string playerNum = (name[name.Length - 1]).ToString();
        
        moveInput = new Vector3(Input.GetAxisRaw("LHorizontal"+playerNum), 0f, -Input.GetAxisRaw("LVertical"+playerNum));
        moveVelocity = moveInput * moveSpeed;
        //rotate with mouse
        if (!useController)
        {
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
            if (Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }
            //if (Input.GetMouseButtonDown(1))
            //{
            //    shield.SetActive(true);
            //    Invoke("ShieldOff", 1);
                
            //}
        }

    //rotate with controller
    else
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal"+playerNum) + Vector3.forward * -Input.GetAxisRaw("RVertical1");
           
            switch (playerNum)
            {
                case "1":
                  
                    if (Mathf.Round(Input.GetAxis("P1Aoe")) < 0)
                        theGun.isFiring = true;
                    
                    if (Mathf.Round(Input.GetAxis("P1Aoe")) == 0)
                        theGun.isFiring = false;
                    
                    break;
                case "2":
                    playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal2") + Vector3.forward * -Input.GetAxisRaw("RVertical2");
                    if (Mathf.Round(Input.GetAxis("P2Aoe")) < 0)
                        theGun.isFiring = true;
                    if (Mathf.Round(Input.GetAxis("P2Aoe")) == 0)
                        theGun.isFiring = false;
                    break;
                case "3":
                    playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal3") + Vector3.forward * -Input.GetAxisRaw("RVertical3");
                    if (Mathf.Round(Input.GetAxis("P3Aoe")) < 0)
                        theGun.isFiring = true;
                    if (Mathf.Round(Input.GetAxis("P3Aoe")) == 0)
                        theGun.isFiring = false;
                    break;
                case "4":
                    playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal4") + Vector3.forward * -Input.GetAxisRaw("RVertical4");
                    if (Mathf.Round(Input.GetAxis("P4Aoe")) < 0)
                        theGun.isFiring = true;
                    if (Mathf.Round(Input.GetAxis("P4Aoe")) == 0)
                        theGun.isFiring = false;
                    break;
            }
            
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
            
        }
    }
    void FixedUpdate(){
        myRigidBody.AddForce( moveVelocity,ForceMode.VelocityChange);
    }

    //void ShieldOff()
    //{
    //    shield.SetActive(false);
    //}

}
*/