using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashExample : MonoBehaviour {

    public int myInt;
    [HashLine(3)]
    [CustomObject]
    public GameObject myObj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
