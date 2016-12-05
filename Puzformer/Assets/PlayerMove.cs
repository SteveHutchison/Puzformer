using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    Rigidbody2D rb2d;
    public float horV;
    public float maxHorVel;
    public bool CanJump;
    public Vector3 StartP;
	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        CanJump = false;
        StartP = this.transform.position;
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
        if (Input.GetKey("up") && CanJump)
        {
            rb2d.AddForce(new Vector3(0, 300, 0));
            CanJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            CanJump = true;
            //animator.SetBool("jumping", false);
        }

        if (coll.gameObject.tag == "death")
        {
            this.transform.position = StartP;
            //animator.SetBool("jumping", false);
        }
    }
    /*
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            CanJump = false;
            //animator.SetBool("jumping", false);
        }
    }
    */
    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "Pickup")
        {
            Destroy(coll.gameObject);
        }
    
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        /*
        if (coll.gameObject.tag == "Raising")
        {
            
        }
        */
    }
}
