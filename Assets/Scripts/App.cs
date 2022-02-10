using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class App : MonoBehaviour
{
    // this is the central point where all app components are linked to
    public SavingsManager savingsManager;
    public DonateManager donateManager;
    public BubbleController bubbleController;
    public VineManager vineManager;
    public UIController uiController;
    public DisplayController displayController;

    private ARTrackedImageManager imageTracker;

    public bool model_tracked = false;
    // Start is called before the first frame update
    void Start()
    {
        uiController = GameObject.Find("UI").GetComponent<UIController>();

        // get imageTracker
        imageTracker = GameObject.Find("AR Session Origin")
            .GetComponent<ARTrackedImageManager>();

        //if we are in the editor
        if (GameObject.Find("spawnPRefab"))
        {
            model_tracked = true;
            InitializeApp();
        }
    }


    // subscribe to imageTracker state changed events
    void OnEnable() => imageTracker.trackedImagesChanged += OnChanged;

    void OnDisable() => imageTracker.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        InitializeApp();
        foreach (var newImage in eventArgs.added)
        {
            InitializeApp();
        }

        foreach (var removedImage in eventArgs.removed)
        {
            model_tracked = false;
        }
    }

    public void InitializeApp()
    {
        model_tracked = true;
        // get all app components
        bubbleController = GameObject.Find("Particle System")
            .GetComponent<BubbleController>();

        donateManager = GameObject.Find("addTree")
            .GetComponent<DonateManager>();

        displayController = GameObject.Find("carbonDisplay")
            .GetComponent<DisplayController>();

        savingsManager = GameObject.Find("reset")
           .GetComponent<SavingsManager>();

        vineManager = GameObject.Find("vines").GetComponent<VineManager>();

    }

}