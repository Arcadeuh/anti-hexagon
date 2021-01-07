using System.Collections.Generic;
using UnityEngine;

public class PartitionCreation : MonoBehaviour
{
    [SerializeField] private List<GameObject> tiles;
    [SerializeField] private GameObject nullGameObject;

    private List<TilePartition> partitions = new List<TilePartition>();

    private void Start()
    {
        List<List<GameObject>> partition4 = new List<List<GameObject>>
        {
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{tiles[0], tiles[0], nullGameObject , nullGameObject , nullGameObject, nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, tiles[1], tiles[1], nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject, nullGameObject , tiles[0], tiles[0], nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject, nullGameObject, nullGameObject , nullGameObject , nullGameObject, tiles[1], tiles[0] }
        };
        partitions.Add(new TilePartition(1, partition4));

        List<List<GameObject>> blankPartition = new List<List<GameObject>>
        {
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject },
            new List<GameObject>{nullGameObject, nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject , nullGameObject }
        };
        partitions.Add(new TilePartition(1, blankPartition));
    }
}
