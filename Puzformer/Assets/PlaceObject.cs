using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {
    public Transform[] blocks;
    public Sprite[] sprites;
    private Vector3 newPosition;
    private GameObject touching;
    public bool istouching;
    public float offsetx, offsety;
    private int blocktype;
    // Use this for initialization
    void Start () {
        blocktype = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            //newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition = transform.position;
            offsetx = newPosition.x % 1;
            offsety = newPosition.y % 1;
          
            Instantiate(blocks[blocktype], new Vector3(newPosition.x - offsetx, newPosition.y - offsety, 0), Quaternion.identity);
                         
        }

        if(Input.GetKeyDown("1"))
        {            
            blocktype = 0;
            this.GetComponent<SpriteRenderer>().sprite = sprites[blocktype];
        }
        if (Input.GetKeyDown("2"))
        {
            blocktype = 1;
            this.GetComponent<SpriteRenderer>().sprite = sprites[blocktype];
        }
        if (Input.GetKeyDown("3"))
        {
            blocktype = 2;
            this.GetComponent<SpriteRenderer>().sprite = sprites[blocktype];
        }
        if (Input.GetKeyDown("4"))
        {
            blocktype = 3;
            this.GetComponent<SpriteRenderer>().sprite = sprites[blocktype];
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(istouching == true)
            {
                Destroy(touching);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Floor" || coll.gameObject.tag == "bounce" || coll.gameObject.tag == "death" || coll.gameObject.tag == "Pickup")
        {
            istouching = true;
            touching = coll.gameObject;
        }

    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "bounce" || coll.gameObject.tag == "death" || coll.gameObject.tag == "Pickup")
        {
            istouching = false;
        }
    }
}
