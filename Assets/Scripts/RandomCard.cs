using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomCard : MonoBehaviour
{
    public Sprite[] card;
    public SpriteRenderer cardRenderer;
    private int number;
    // Start is called before the first frame update
    void Start()
    {
        RandomImage();
    }
    private void RandomImage()
    {
        number = Random.Range(0, card.Length);
        cardRenderer.sprite = card[number];
    }
}
