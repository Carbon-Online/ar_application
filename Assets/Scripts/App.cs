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
    public TourManager tourManager;
    public TourUIController tourUIController;

    private ARTrackedImageManager imageTracker;

    public bool model_tracked = false;
    // Start is called before the first frame update
    void Start()
    {
        // get imageTracker
        imageTracker = GameObject.Find("AR Session Origin")
            .GetComponent<ARTrackedImageManager>();

        //imageTracker.trackedImagesChanged += OnChanged;

        uiController = GameObject.Find("UI").GetComponent<UIController>();

        tourManager = transform.GetComponent<TourManager>();

        tourManager.StartTour();

        //if we are in the editor
        if (GameObject.Find("spawnPRefab"))
        {
            model_tracked = true;
            InitializeApp();
        }
    }

    public void Update()
    {
        if (GameObject.Find("tourUI") && !model_tracked)
            InitializeApp();
        if (!GameObject.Find("tourUI") && model_tracked)
            ModelLost();
    }

    //void OnDisable() => imageTracker.trackedImagesChanged -= OnChanged;

    //void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    //{
    //    if (GameObject.Find("spawnPRefab"))
    //        InitializeApp();
    //}

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

        tourUIController = GameObject.Find("tourUI")
            .GetComponent<TourUIController>();
        // start the guided tour
        tourManager.StartTour();
    }

    public void Reset()
    {
        PlayerPrefs.SetFloat("totalGrow", 0f);
        PlayerPrefs.SetInt("numBubbles", 0);

        if (model_tracked)
        {
            vineManager.ResetVines();
            bubbleController.ResetBubbles();
            displayController.UpdateCarbonDisplay();
        }
    }

    private void ModelLost()
    {
        model_tracked = false;
    }

}
