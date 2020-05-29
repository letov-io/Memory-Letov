using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BoardController : MonoBehaviour
{
    [SerializeField]
    private MemoryCard originalCard;

    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private TMP_Text scoreLabel;

    public const int columns = 4;
    public const int rows = 2;
    public const float marginHor = 4f;
    public const float marginVer = 5f;

    private int mistakes = 0;

    private MemoryCard first;
    private MemoryCard second;

    public bool canReveal {
        get {
            return second == null;
        }
    }

    private void Restart () {
        SceneManager.LoadScene("Game");
    }
    public void RevealCard (MemoryCard card) {
        if (first == null) {
            first = card;
            return;
        }

        if (second == null) {
            second = card;
            StartCoroutine(CheckMatch());
        }
    }
    void Start() {
        mistakes = 0;
        AssignMistakeText(mistakes);

        var origin = originalCard.transform.position;
        var pairs = Utils.ShuffleArray(GenPairs());

        for (int index = 0; index < columns * rows; index += 1) {
            MemoryCard newCard;

            if (index > 0) {
                newCard = Instantiate(originalCard) as MemoryCard;
                newCard.transform.parent = gameObject.transform;
            } else {
                newCard = originalCard;
            }

            int id = pairs[index];
            newCard.SetCard(id, images[id]);

            var x = index % columns;
            var y = index / columns;

            float posX = origin.x + x * marginHor;
            float posY = origin.y + y * marginVer;

            newCard.transform.position = new Vector3(posX, posY, origin.z);
        }
    }

    int[] GenPairs () {
        int[] tmp = new int[columns * rows];
        for (int i = 0; i < columns * rows; i += 2) {
            tmp[i]   = i / rows;
            tmp[i+1] = i / rows;
        }
        return tmp;
    }

    private IEnumerator CheckMatch () {
        if (second.GetId() != first.GetId()) {
            yield return new WaitForSeconds(1);
            AssignMistakeText(++mistakes);
            first.Unreveal();
            second.Unreveal();
        }
        first = null;
        second = null;
    }

    private void AssignMistakeText (int mis) {
        var times = Utils.IsPlural(mis) ? " раза." : " раз.";
        scoreLabel.text = "Отряд не заметил потери бойца " + mis + times;
    }
}
