using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{

    public Root root;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            root.ReloadLevel();
        }
    }
}
