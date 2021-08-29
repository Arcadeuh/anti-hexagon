using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent onTileShot;
    private Animator menuAnimator;

    private void Start()
    {
        menuAnimator = GameObject.Find("Menu").GetComponent<Animator>();
    }

    public void tileShot()
    {
        onTileShot.Invoke();
    }

    public void setPlay(bool value)
    {
        menuAnimator.SetBool("play", value);
    }

    public void setLose(bool value)
    {
        menuAnimator.SetBool("lose", value);
    }

    public void setModeX(bool value)
    {
        menuAnimator.SetBool("modeX", value);
    }

    public void setBack(bool value)
    {
        menuAnimator.SetBool("back", value);
    }

    public void setRetry(bool value)
    {
        menuAnimator.SetBool("retry", value);
    }

    public void setQuit(bool value)
    {
        menuAnimator.SetBool("quit", value);
    }
}
