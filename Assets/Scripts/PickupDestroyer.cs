using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CleanUp")
        {
            Destroy(collision.gameObject);
        }
    }
}