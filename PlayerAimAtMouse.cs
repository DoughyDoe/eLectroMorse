using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimAtMouse : MonoBehaviour {
    // Use this for initialization
    void Start () {
        
}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        float x = transform.position.x - mousePos.x;
        float y = transform.position.y - mousePos.y;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
