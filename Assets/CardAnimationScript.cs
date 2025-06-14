using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimationScript : MonoBehaviour
{
    public AnimationScript animationScript;
    public void Disapear()
    {
        animationScript.DisableCard();
    }
}
