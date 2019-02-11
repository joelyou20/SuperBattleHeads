using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public bool isOnDropPlatform = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    void Move()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wait(1f);
        if (collision != null)
        {
            if (collision.gameObject.GetComponent<DropFromPlatform>() != null)
            {
                isOnDropPlatform = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.GetComponent<DropFromPlatform>() != null)
            {
                isOnDropPlatform = false;
            }
        }
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
