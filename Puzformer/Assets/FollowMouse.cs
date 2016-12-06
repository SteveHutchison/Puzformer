using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
    Vector3 newPosition;
	// Use this for initialization
	void Start () {
	    newPosition = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float offsetx = newPosition.x % 1;
        float offsety = newPosition.y % 1;
        newPosition.x -= offsetx;
        newPosition.y -= offsety;
        newPosition.z = 0.0f;
        transform.position = newPosition; 
    }
}
