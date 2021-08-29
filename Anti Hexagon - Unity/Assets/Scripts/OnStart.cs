using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    [SerializeField] private Animator menuAnimator;

    // Start is called before the first frame update
    void Start()
    {
        SaveObject saveObject = SaveSystem.load();
        Debug.Log(saveObject);
        if (saveObject == null)
        {
            Debug.Log("Save file initiated");
            saveObject = new SaveObject(1000, 1000);
            SaveSystem.save(saveObject);
            GameObject[] listScoreTile = GameObject.FindGameObjectsWithTag("BestscoreTile");
            foreach (GameObject scoreTile in listScoreTile)
            {
                scoreTile.GetComponent<BestscoreTile>().updateText();
            }
            return;
        }
        menuAnimator.Play("ABaseIn");
    }
}
