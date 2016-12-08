using UnityEngine;
using System.Collections;

public class CurrentBoard : MonoBehaviour {

    private GameObject[,] cBoard;
    public GameObject concrete;

	// Use this for initialization
	void Start () {
        cBoard = new GameObject[101,101];
	    for (int i = 0; i < 101; i++)
        {
            if (concrete != null)
            {
                cBoard[0, i] = concrete;
                cBoard[i, 0] = concrete;
                cBoard[100, i] = concrete;
                cBoard[i, 100] = concrete;
                /*
                Instantiate(cBoard[0, i].transform, new Vector3(0, i, 0), Quaternion.identity);
                Instantiate(cBoard[i, 0].transform, new Vector3(i, 0, 0), Quaternion.identity);
                Instantiate(cBoard[100, i].transform, new Vector3(100, i, 0), Quaternion.identity);
                Instantiate(cBoard[i, 100].transform, new Vector3(i, 100, 0), Quaternion.identity);
                */
            }
        }
	}

    public bool CheckSpace(int x, int y)
    {
        if (cBoard[x, y] == null)
        {
            return true;
        }
        else if (cBoard[x, y].tag != "concrete")
        {
            return true;
        }
        else return false;
    }
	
	// Update is called once per frame
	void Update () {
        //overwrite current scene
        if (Input.GetKeyDown("s"))
        {
            UnityEditor.EditorApplication.SaveScene("newScene" ,true);
        }

    }
}
