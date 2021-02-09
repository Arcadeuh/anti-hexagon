using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int pulsationsBeforeTilesDestroyed;
    [SerializeField] private List<TileSpawner> spawners;
    [SerializeField] private List<Partition> partitions;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Partition part in partitions)
        {
            part.init();
        }

        foreach(TileSpawner spawner in spawners)
        {
            spawner.setHeartbeatCountBeforeTileDestroyed(pulsationsBeforeTilesDestroyed);
        }
    }

    private IEnumerator chargePartition()
    {
        foreach(Partition partition in partitions)
        {
            int offset = Mathf.FloorToInt(Random.Range(0.0f, 7.0f));
            loadPartition(partition, offset);
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

    // Update is called once per frame
    void Update()
    {
        if(spawners[0].queue.Count == 0) { StartCoroutine("chargePartition"); }
    }
}
