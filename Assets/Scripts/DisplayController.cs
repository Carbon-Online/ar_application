using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayController : MonoBehaviour
{

    private TMP_Text carbonDisplay;
    // Start is called before the first frame update
    void Start()
    {
        carbonDisplay = transform.GetComponent<TMP_Text>();
        UpdateCarbonDisplay();
    }

    public void UpdateCarbonDisplay()
    {
        int numBubbles = PlayerPrefs.GetInt("numBubbles");
        carbonDisplay = GameObject.Find("carbonDisplay").GetComponent<TMP_Text>();
        carbonDisplay.text = "You have safed \n" +
                                numBubbles.ToString() +
                                " kilogramms \n of carbon.";
    }
}
