using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    Rigidbody2D rb2d;
    public float horV, vertV;
    public float maxHorVel;
    public bool CanJump;
    public Vector3 StartP, CurrentSpawn;
    public bool Editing;
	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        CanJump = false;
        Editing = false;
        StartP = this.transform.position;
        CurrentSpawn = StartP;
    }
	
	// Update is called once per frame
	void Update () {
        if (!Editing)
        {
            horV = rb2d.velocity.x;
            vertV = rb2d.velocity.y;

            if (vertV > 0.25 || vertV < -0.25)
            {
                CanJump = false;
            }

            if (Input.GetKey("left") && rb2d.velocity.x > -maxHorVel)
            {
                rb2d.AddForce(new Vector3(-10, 0, 0));
            }
            if (Input.GetKey("right") && rb2d.velocity.x < maxHorVel)
            {
                rb2d.AddForce(new Vector3(10, 0, 0));
            }
            if (Input.GetKeyDown("up") && CanJump)
            {
                rb2d.AddForce(new Vector3(0, 450, 0));
                CanJump = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "concrete")
        {
            CanJump = true;
            //animator.SetBool("jumping", false);
        }

        if (coll.gameObject.tag == "death")
        {
            this.transform.position = CurrentSpawn;
        }
    }
 
    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "Pickup")
        {
            Destroy(coll.gameObject);
        }
    
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        
    }
}
