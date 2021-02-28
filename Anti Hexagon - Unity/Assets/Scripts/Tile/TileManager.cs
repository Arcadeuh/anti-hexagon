using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private float pulsationsBeforeTilesDestroyed;
    [SerializeField] private List<TileSpawner> spawners;
    [SerializeField] private List<Partition> partitions;
    [SerializeField] private Partition transitionPartition;

    [SerializeField] private bool enableTransitions = false;
    [SerializeField] private bool enableRandom = false;
    [SerializeField] private bool enableOffset = false;
    [SerializeField] private bool withWall = true;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Partition part in partitions)
        {
            part.init();
        }

        transitionPartition.init();

        foreach(TileSpawner spawner in spawners)
        {
            spawner.setHeartbeatCountBeforeTileDestroyed(pulsationsBeforeTilesDestroyed);
        }
    }

    private IEnumerator chargePartition()
    {
        for(int i=0; i<partitions.Count; i++)
        {
            int indexPartition = i;
            if (enableRandom)
            {
                indexPartition = Mathf.FloorToInt(Random.Range(0.0f, partitions.Count - 1));
            }
            if (partitions[indexPartition].containingWall && !withWall) { continue; }

            int offset = 0;
            if (enableOffset)
            {
                offset = Mathf.FloorToInt(Random.Range(0.0f, 3.0f)) * 2;
            }

            if (enableTransitions)
            {
                loadPartition(transitionPartition, offset);
            }
            loadPartition(partitions[indexPartition], offset);
        }
        yield return null;
    }

    private void loadPartition(Partition partition, int offset)
    {
        foreach (Accord accord in partition.listAccords)
        {
            for (int i = 0; i < 8; i++)
            {
                spawners[(i + offset) % 8].addToQueue(accord.notes[i]);
            }
        }
    }

    public void destroyTilesOnScreen()
    {
        GameObject[] tilesFound = GameObject.FindGameObjectsWithTag("Tile");
        foreach(GameObject tile in tilesFound)
        {
            Destroy(tile);
        }
        tilesFound = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject tile in tilesFound)
        {
            Destroy(tile);
        }
    }

    public void clearQueues()
    {
        foreach(TileSpawner spawner in spawners)
        {
            spawner.clearQueue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawners[0].queue.Count == 0) { StartCoroutine("chargePartition"); }
    }
}
