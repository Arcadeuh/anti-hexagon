using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Partition", menuName ="Partition")]
public class Partition : ScriptableObject
{
    public GameObject fillingGameObject;
    public List<Accord> listAccords;
    public OffsetType offset = OffsetType.None;
    [Range(1, 5)] public int difficulty = 3;
    public bool containingWall = false;
    public bool reversable = false;
    [Range(0, 4)] public int nbColors = 1;
    

    public void init()
    {
        fillTheBlank();
    }

    private void fillTheBlank()
    {
        for (int i = 0; i < listAccords.Count; i++)
        {
            for (int j = 0; j < listAccords[i].notes.Count; j++)
            {
                if (listAccords[i].notes[j] == null)
                {
                    listAccords[i].notes[j] = fillingGameObject;
                }
            }
        }
    }
}

[System.Serializable]
public enum OffsetType
{
    None = 1,
    Demi = 2,
    Quart = 4,
    Huitieme = 8
}

[System.Serializable]
public class Accord
{
    public List<GameObject> notes;
}
