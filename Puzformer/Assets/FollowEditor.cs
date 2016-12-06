using UnityEngine;
using System.Collections;

public class FollowEditor : MonoBehaviour {

    Transform player;
    public float offsetX;
    float offsetY;
    public float mousez;

    // Use this for initialization
    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("EditMouse");

        player = player_go.transform;

        offsetX = 0;
        offsetY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;
        Vector3 pos = transform.position;
        if (offsetX > 6)
        {
            pos.x = transform.position.x - 0.2f;
            transform.position = pos;
        }
        else if (offsetX < -6)
        {
            pos.x = transform.position.x + 0.2f;
            transform.position = pos;
        }
        if (offsetY > 3)
        {
            pos.y = transform.position.y - 0.2f;
            transform.position = pos;
        }
        else if (offsetY < -3)
        {
            pos.y = transform.position.y + 0.2f;
            transform.position = pos;
        }
   
        mousez = Input.GetAxis("Mouse ScrollWheel") * 2;
        float camsize = Camera.main.orthographicSize;
        camsize -= mousez;
        Camera.main.orthographicSize = camsize;
    }
}
