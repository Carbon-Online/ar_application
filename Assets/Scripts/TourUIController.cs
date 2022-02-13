using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class TourUIController : MonoBehaviour
{
    private TourButtonController tourButtonController;
    private TMP_Text tourButtonText;

    private TMP_Text tourText;
    // Start is called before the first frame update
    void Start()
    {
        tourButtonController = GameObject.Find("tourButton")
            .GetComponent<TourButtonController>();
    
        tourText = GameObject.Find("tourDisplay").GetComponent<TMP_Text>();
        tourText.DOColor(Color.clear, 0f);
    }

    public void UpdateTourUI(string msg, UnityAction callback)
    {

        tourButtonController.AssignOnClick(() => {
            Debug.Log("tourUIButton clicked.");
            callback();
            tourText.DOBlendableColor(Color.clear, 0f);
        });

        tourText.DOColor(Color.black, 0.3f);
        tourText.text = msg;
        Debug.Log("Tour UI updated and ready.");
    }
}
