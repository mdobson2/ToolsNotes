using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Level : MonoBehaviour {

    public int myInt;
    [HashLine(3)]
    public int myInt2;

    public int width;
    public int height;

    [TimeFormat(false)]
    public int timeAllowed;

    public float gravity;

    public GameObject left, right, top, bottom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResizeLevel()
    {
        left.transform.position = new Vector3(-(width / 2), 0);
        left.transform.localScale = new Vector3(1, height);

        right.transform.position = new Vector3((width / 2), 0);
        right.transform.localScale = new Vector3(1, height);

        top.transform.position = new Vector3(0, (height / 2));
        top.transform.localScale = new Vector3(width, 1);

        bottom.transform.position = new Vector3(0, -(height / 2));
        bottom.transform.localScale = new Vector3(width, 1);
    }
}
