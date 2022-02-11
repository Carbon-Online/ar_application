using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class TourUIController : MonoBehaviour
{
    private TMP_Text tourButton;
    private TourButtonController tourButtonController;
    private TMP_Text tourButtonText;

    private TMP_Text tourText;
    // Start is called before the first frame update
    void Start()
    {
        tourButton = GameObject.Find("tourButton").GetComponent<TMP_Text>();
        tourButtonController = tourButton.GetComponent<TourButtonController>();
    
        tourText = GameObject.Find("tourDisplay").GetComponent<TMP_Text>();
        tourButton.DOColor(Color.clear, 0f);
        tourText.DOColor(Color.clear, 0f);

    }

    public void UpdateTourUI(string msg, string buttonText, UnityAction callback)
    {

        tourButtonController.AssignOnClick(() => {
            Debug.Log("tourUIButton clicked.");
            callback();
            tourButton.DOColor(Color.clear, 0.3f);
            tourText.DOColor(Color.clear, 0.3f);
        });
        tourButton.DOColor(Color.red, 0.3f);
        tourText.DOColor(Color.red, 0.3f);
        tourButton.text = buttonText;
        tourText.text = msg;
    }
}
