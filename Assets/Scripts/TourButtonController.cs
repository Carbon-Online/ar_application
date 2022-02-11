using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TourButtonController : MonoBehaviour
{

    private System.Action onClickFunc;

    public void AssignOnClick(System.Action callback)
    {
        onClickFunc = callback;
    }
    // Update is called once per frame
    private void OnMouseUpAsButton()
    {
        transform.DOShakePosition(0.2f, new Vector3(0.005f, 0.005f, 0.005f), 20)
            .OnComplete(() => onClickFunc());
    }
}
