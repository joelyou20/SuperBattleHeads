using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class DropFromPlatform : MonoBehaviour {

    private GameObject playerObject;
    private Player playerScript;
    private CircleCollider2D playerCircleCollider;
    private BoxCollider2D playerBoxCollider;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.S) &&
           Input.GetKey(KeyCode.Space) &&
           playerScript.isOnDropPlatform &&
           playerObject != null)
        {
            Invoke("DropOn", 0.01f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        playerObject = collision2D.gameObject;
        playerScript = playerObject.GetComponent<Player>();
        playerCircleCollider = playerObject.GetComponent<CircleCollider2D>();
        playerBoxCollider = playerObject.GetComponent<BoxCollider2D>();
    }

    private void DropOn()
    {
        Physics2D.IgnoreCollision(playerCircleCollider.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>(), true);
        Physics2D.IgnoreCollision(playerCircleCollider.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>(), true);

        Invoke("DropOff", 1f);
    }

    private void DropOff()
    {
        Physics2D.IgnoreCollision(playerCircleCollider.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>(), false);
        Physics2D.IgnoreCollision(playerCircleCollider.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>(), false);
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
