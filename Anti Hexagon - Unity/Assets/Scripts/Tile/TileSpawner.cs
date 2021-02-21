using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public Queue<GameObject> queue = new Queue<GameObject>();

    [SerializeField] private float pulsationtBeforeTileDestroyed = 3;
    [SerializeField] private GameObject sceneManager;
    [SerializeField] private GameObject centerCollision;
    [SerializeField] private bool tileVisibleInsideMask = true;

    public void spawnTile()
    {
        if(queue.Count == 0){ return; }

        GameObject thisTile = queue.Dequeue();

        if (thisTile.tag == "test") { return; }
        
        thisTile.GetComponent<TileGameObject>().setCorridor(transform.parent.gameObject);
        
        float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), Vector2.zero) 
            - centerCollision.GetComponent<CircleCollider2D>().radius * centerCollision.transform.localScale.x;

        thisTile.GetComponent<Translator>().setSpeed(distance, sceneManager.GetComponent<Rythm>().rythm * pulsationtBeforeTileDestroyed);

        if (tileVisibleInsideMask)
        {
            thisTile.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
        else
        {
            thisTile.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }

        Instantiate(thisTile, transform.position, transform.rotation);
    }

    public void addToQueue(GameObject gameObject)
    {
        queue.Enqueue(gameObject);
    }

    public void clearQueue()
    {
        queue.Clear();
    }

    public void setHeartbeatCountBeforeTileDestroyed(float pulsation)
    {
        pulsationtBeforeTileDestroyed = pulsation;
    }
}
