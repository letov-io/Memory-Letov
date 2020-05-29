using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField]
    private GameObject cardBack;

    [SerializeField]
    private BoardController board;

    private int id;

    public int GetId () {
        return id;
    }

    public void SetCard (int number, Sprite image) {
        id = number;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    private void OnMouseDown() {
        if (cardBack.activeSelf && board.canReveal) {
            cardBack.SetActive(false);
            board.RevealCard(this);
        }
    }

    public void Unreveal () {
        cardBack.SetActive(true);
    }
}
