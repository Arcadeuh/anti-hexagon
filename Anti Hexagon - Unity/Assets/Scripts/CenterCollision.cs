using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CenterCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent onTileCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            Destroy(collision.gameObject);
            onTileCollision.Invoke();
        }
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
        }
    }
}
