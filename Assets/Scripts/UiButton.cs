using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private string message;
    private void OnMouseUp() {
        if (target != null) {
            target.SendMessage(message);
        }
    }

}
