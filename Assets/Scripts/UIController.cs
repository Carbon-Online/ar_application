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

    private VisualElement menu;
    private Button menuButton;
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
        menu = uiRoot.Q<VisualElement>("menu");
        menuButton = uiRoot.Q<Button>("menuButton");
        resetButton = uiRoot.Q<Button>("resetButton");

        alert = uiRoot.Q<VisualElement>("alert");
        alertLabel = uiRoot.Q<Label>("alertLabel");
        alertButton = uiRoot.Q<Button>("alertButton");

        dayBar = uiRoot.Q<ProgressBar>("dayBar");
        dayCounter = uiRoot.Q<Label>("dayCounter");
        // hide alert and menu
        alert.style.display = DisplayStyle.None;
        menu.style.display = DisplayStyle.None;


        // callback for menu button
        menuButton.RegisterCallback<ClickEvent>(
            ev => ToggleMenu());

        // callback for reset button
        resetButton.RegisterCallback<ClickEvent>(
            ev =>
            {
                ToggleMenu();
                app.tourManager.StartTour();
                
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleMenu()
    {
        if (menu.style.display == DisplayStyle.Flex)
        {
            DOTween.To(x => menu.style.opacity = x, 1, 0, .3f).OnComplete(
                () => { menu.style.display = DisplayStyle.None; }
                );
        }
        else
        {
            menu.style.display = DisplayStyle.Flex;
            DOTween.To(x => menu.style.opacity = x, 0, 1, .3f);
        }
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
        dayCounter.text = dayCount.ToString();
    }
}
