using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int pulsationsBeforeTilesDestroyed;
    [SerializeField] private List<TileSpawner> spawners;
    [SerializeField] private List<GameObject> tiles;
    [SerializeField] private GameObject nullGameObject;

    private List<TilePartition> partitions = new List<TilePartition>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(TileSpawner spawner in spawners)
        {
            spawner.setHeartbeatCountBeforeTileDestroyed(pulsationsBeforeTilesDestroyed);
        }

        List<List<GameObject>> partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, tiles[0], nullGameObject , nullGameObject , nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , tiles[0], nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[0], nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, tiles[0], nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , tiles[0], nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[0] }
        };
        partitions.Add(new TilePartition(0, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[0], nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, tiles[0], nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, tiles[0], nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, tiles[0], nullGameObject, nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject, tiles[0], nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , tiles[0], nullGameObject, nullGameObject , nullGameObject, nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[0] },
        };
        partitions.Add(new TilePartition(0, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , nullGameObject , tiles[0] },
            new List<GameObject>{tiles[1], nullGameObject, nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , nullGameObject , tiles[1] },
        };
        partitions.Add(new TilePartition(1, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[1], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, tiles[1], nullGameObject, nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[0], nullGameObject, nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[0], nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[1], nullGameObject, nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , tiles[1], nullGameObject },
        };
        partitions.Add(new TilePartition(1, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[1], nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, tiles[0], nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, tiles[1], nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, tiles[0], nullGameObject, nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject, tiles[1], nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , tiles[0], nullGameObject, nullGameObject , nullGameObject, nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[1] },
        };
        partitions.Add(new TilePartition(1, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject, tiles[0], nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject, nullGameObject, nullGameObject, nullGameObject , tiles[0], nullGameObject },
        };
        partitions.Add(new TilePartition(1, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[1] },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, nullGameObject , tiles[1], nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, nullGameObject, tiles[1], nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , nullGameObject, tiles[1], nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject , tiles[1], nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , tiles[1], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, tiles[1], nullGameObject , nullGameObject , nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[1], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
        };
        partitions.Add(new TilePartition(1, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject }
        };
        partitions.Add(new TilePartition(1, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[1], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[2], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{ tiles[3], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
        };
        partitions.Add(new TilePartition(1, partition));

        partition = new List<List<GameObject>>
        {
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{ tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{ tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{ tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{ tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{ tiles[0], nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject }
        };
        partitions.Add(new TilePartition(1, partition));
    }

    private IEnumerator chargePartition()
    {
        foreach(TilePartition partition in partitions)
        {
            if (partition.maxType <= 1)
            {
                int offset = Mathf.FloorToInt(Random.Range(0.0f, 7.0f));
                loadPartition(partition, offset);
            }
        }
        yield return null;
    }

    private void loadPartition(TilePartition partition, int offset)
    {
        foreach(List<GameObject> note in partition.getPartition())
        {
            for(int i=0; i<8; i++)
            {
                spawners[(i+offset)%8].addToQueue(note[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawners[0].queue.Count == 0) { StartCoroutine("chargePartition"); }
    }
}
