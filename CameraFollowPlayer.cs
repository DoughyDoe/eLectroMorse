using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
    public GameObject player;
    private float sceneGridX = 0;
    private float sceneGridY = 0;
    public float roomWidth;
    public float roomHeight;
	// Use this for initialization
	void Start () {
        float px = Mathf.Ceil(player.transform.position.x);
		float py = Mathf.Ceil(player.transform.position.y);
        sceneGridX = Mathf.Ceil(px / roomWidth);
        sceneGridY = Mathf.Ceil(py / roomHeight);
        float x = (roomWidth / 2) + ((sceneGridX-1) * roomWidth);
        float y = (roomHeight / 2) + ((sceneGridY-1) * roomHeight);
        transform.position = new Vector3 (x, y,transform.position.z);
        Debug.Log("Script ran");
    }
	
	// Update is called once per frame
	void Update () {
        if (player == null) return;
        float px = Mathf.Ceil(player.transform.position.x);
        float py = Mathf.Ceil(player.transform.position.y);
        float sceneGridXnew = Mathf.Ceil(px / roomWidth);
        float sceneGridYnew = Mathf.Ceil(py / roomHeight);
        if (sceneGridX != sceneGridXnew)
        {
            sceneGridX = sceneGridXnew;
            Debug.Log("X changed");
            Debug.Log(sceneGridX);
        }
        if (sceneGridY != sceneGridYnew)
        {
            sceneGridY = sceneGridYnew;
            Debug.Log("Y changed");
            Debug.Log(sceneGridY);
        }
        float newx = (roomWidth / 2) + ((sceneGridX-1) * roomWidth);
        float newy = (roomHeight / 2) + ((sceneGridY-1) * roomHeight);
        transform.position = new Vector3 (Mathf.Lerp(transform.position.x,newx,0.1f), Mathf.Lerp(transform.position.y, newy, 0.1f),transform.position.z);
    }
}
