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
    [SerializeField] private bool enableWall = true;

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


    public void setVariables(bool transition, bool random, bool offset, bool wall)
    {
        enableTransitions = transition;
        enableRandom = random;
        enableOffset = offset;
        enableWall = wall;
    }

    private IEnumerator chargePartition()
    {
        for(int i=0; i<partitions.Count; i++)
        {
            int indexPartition = i;
            if (enableRandom)
            {
                indexPartition = Mathf.FloorToInt(Random.Range(0.0f, partitions.Count-0.01f));
            }
            Debug.Log(indexPartition);
            if (partitions[indexPartition].containingWall && !enableWall) { continue; }

            int offset = 0;
            if (enableOffset)
            {
                offset = (int)partitions[indexPartition].offset;
                offset = 8/offset * (Mathf.FloorToInt(Random.Range(0.0f, 7.99f))%offset) % 8;
            }

            if (enableTransitions)
            {
                loadPartition(transitionPartition);
            }
            loadPartition(partitions[indexPartition], offset);
        }
        yield return null;
    }

    public void loadPartition(Partition partition, int offset)
    {
        int reverse = 0;
        if (partition.reversable)
        {
            reverse = Mathf.FloorToInt(Random.Range(0.0f, 1.9999f));
        }
        if (reverse == 0)
        {
            for (int i = 0; i<partition.listAccords.Count; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    spawners[(j + offset) % 8].addToQueue(partition.listAccords[i].notes[j]);
                }
            }
        }
        else
        {
            for (int i = partition.listAccords.Count-1; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    spawners[(j + offset) % 8].addToQueue(partition.listAccords[i].notes[j]);
                }
            }
        }
        
    }

    public void loadPartition(Partition partition)
    {
        foreach (Accord accord in partition.listAccords)
        {
            for (int i = 0; i < 8; i++)
            {
                spawners[i % 8].addToQueue(accord.notes[i]);
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

    public void subSpeed(float speedSubstracted)
    {
        pulsationsBeforeTilesDestroyed -= speedSubstracted;
        this.updateSpeed();
    }

    public void updateSpeed()
    {
        foreach (TileSpawner spawner in spawners)
        {
            spawner.setHeartbeatCountBeforeTileDestroyed(pulsationsBeforeTilesDestroyed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawners[0].queue.Count == 0) { StartCoroutine("chargePartition"); }
    }
}
