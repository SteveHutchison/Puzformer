using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    Rigidbody2D rb2d;
    public float horV;
    public float maxHorVel;
	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        horV = rb2d.velocity.x;

        if (Input.GetKey("left") && rb2d.velocity.x > -maxHorVel)
        {
            rb2d.AddForce(new Vector3(-10, 0, 0));
        }
        if (Input.GetKey("right") && rb2d.velocity.x < maxHorVel)
        {
            rb2d.AddForce(new Vector3(10, 0, 0));
        }
        if (Input.GetKey("up"))
        {
            rb2d.AddForce(new Vector3(0, 50, 0));
        }
    }
}
