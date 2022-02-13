using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TourButtonController : MonoBehaviour
{
    Material arrowMat;
    Material backgroundMat;
    Color arrowColor;
    Color backgroundColor;
    private System.Action onClickFunc;

    private void Start()
    {
        arrowMat = GameObject.Find("buttonArrow")
            .GetComponent<Renderer>().material;
        arrowColor = Color.white;
        arrowMat.color = Color.clear;

        backgroundMat = GameObject.Find("buttonBackground")
            .GetComponent<Renderer>().material;
        backgroundColor = backgroundMat.color;
        backgroundMat.color = Color.clear;

    }

    public void AssignOnClick(System.Action callback)
    {
        arrowMat.DOColor(arrowColor, 0.4f);
        backgroundMat.DOColor(backgroundColor, 0.4f);
        onClickFunc = callback;
    }
    // Update is called once per frame
    private void OnMouseUpAsButton()
    {
        arrowMat.DOColor(Color.clear, 0.4f)
            .OnComplete(() => onClickFunc());
        backgroundMat.DOColor(Color.clear, 0.4f);
    }
}
