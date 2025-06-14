using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppyAnimationScript : MonoBehaviour
{
    public AnimationScript animationScript;
    public void Disapear()
    {
        animationScript.DisableSister();
    }
}
