using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePartition
{
    private List<List<GameObject>> partition = null;
    public int maxType { get; }

    public TilePartition(int maxType)
    {
        this.maxType = maxType;
    }

    public TilePartition(int maxType, List<List<GameObject>> partition)
    {
        this.maxType = maxType;
        this.partition = partition;
    }

    public List<List<GameObject>> getPartition()
    {
        return partition;
    }

    public void setPartition(List<List<GameObject>> newPartition)
    {
        partition = newPartition;
    }
}
