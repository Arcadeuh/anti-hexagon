using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void setBoolTrue(string boolName)
    {
        animator.SetBool(boolName, true);
    }

    public void setBoolFalse(string boolName)
    {
        animator.SetBool(boolName, false);
    }
}
