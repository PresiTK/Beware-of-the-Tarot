using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void ObtianedCard()
    {
        animator.SetBool("Obtained", true);
    }
    public void AnimationEnded()
    {
        animator.SetBool("Obtained", false);
    }
}
