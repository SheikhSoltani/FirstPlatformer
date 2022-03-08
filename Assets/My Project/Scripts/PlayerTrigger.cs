using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Trap")
        {
            Debug.Log("Trap");
        }
        if (collisionInfo.collider.tag == "Trampoline")
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 10);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "HangGlider")
        {
            col.gameObject.SetActive(false);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }
    }
}
