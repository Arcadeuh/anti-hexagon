using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    [SerializeField] private Animator menuAnimator;

    public void playBase()
    {
        menuAnimator.Play("Base");
    }
}
