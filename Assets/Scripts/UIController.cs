using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class UIController : MonoBehaviour
{
    private App app;

    private VisualElement uiRoot;

    private Button resetButton;

    private VisualElement alert;
    private Label alertLabel;
    private Button alertButton;

    public ProgressBar dayBar;
    public Label dayCounter;

    public int dayCount;

    // Start is called before the first frame update
    void OnEnable()
    {
        dayCount = 0;
        app = GameObject.Find("App").GetComponent<App>();
        // get root
        uiRoot = gameObject.GetComponent<UIDocument>()
            .rootVisualElement;

        // get elements
 
        resetButton = uiRoot.Q<Button>("resetButton");

        alert = uiRoot.Q<VisualElement>("alert");
        alertLabel = uiRoot.Q<Label>("alertLabel");
        alertButton = uiRoot.Q<Button>("alertButton");

        dayBar = uiRoot.Q<ProgressBar>("dayBar");
        dayCounter = uiRoot.Q<Label>("dayCounter");
        // hide alert and menu
        alert.style.display = DisplayStyle.None;

        // callback for reset button
        resetButton.RegisterCallback<ClickEvent>(
            ev =>
            {
                this.StopAllCoroutines();
                app.tourManager.StartTour();
            });
    }



    public void Alert(string msg, string buttonText, Action callback)
    {
        // assign buttontext and message
        alertLabel.text = msg;
        alertButton.text = buttonText;
        // call given callback on click
        alertButton.RegisterCallback<ClickEvent>(
            ev => {
                DOTween.To(x => alert.style.opacity = x, 1, 0, .3f);
                callback();
                }
            );
        // show alert div
        alert.style.display = DisplayStyle.Flex;
        DOTween.To(x => alert.style.opacity = x, 0, 1, .3f);
        
    }

    public bool AnimateDayBar(float d)
    {
        bool done = false;
        DOTween.To(x => dayBar.value = x, 0, 100, d)
                .OnComplete(()=> { done = true; });
        while (!done)
        {
            // wait till animation complete
        }
        return done;
    }

    public void IncrementDayCount()
    {
        dayCount++;
        dayBar.title = "Day: " + dayCount.ToString();
    }

    public void ResetDayBar()
    {
        this.StopAllCoroutines();
        dayCount = 0;
        DOTween.To(x => dayBar.value = x, dayBar.value, 0, 1f);
        dayBar.title = "Day: 0";
    }
}
