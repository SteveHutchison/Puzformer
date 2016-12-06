using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool Editor;
    private GameObject cam, player, editor;

	// Use this for initialization
	void Start () {
        Editor = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        editor = GameObject.FindGameObjectWithTag("EditMouse");

        //Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown("e"))
        {
            if(Editor)
            {
                Editor = false;
                cam.GetComponent<FollowPlayer>().enabled = true;
                cam.GetComponent<FollowEditor>().enabled = false;
                player.GetComponent<PlayerMove>().Editing = false;
                editor.GetComponent<SpriteRenderer>().enabled = false;
                Camera.main.orthographicSize = 5;
            }
            else if (Editor == false)
            {
                Editor = true;
                cam.GetComponent<FollowPlayer>().enabled = false;
                cam.GetComponent<FollowEditor>().enabled = true;
                player.GetComponent<PlayerMove>().Editing = true;
                editor.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
	}
}
