using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSet : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionEnter(Collision collision2D)
    {
        player = collision2D.gameObject;
    }
}
