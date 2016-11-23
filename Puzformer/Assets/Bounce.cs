using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
    private bool bounce;
    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if(bounce == true)
        {
            rb2d.AddForce(new Vector2(0, 500));
            bounce = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "bounce")
        {
            bounce = true;
        }
    }
}
