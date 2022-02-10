using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DonateManager : MonoBehaviour
{
    private App app;
    [SerializeField]
    private int cost_for_grow = 1;
    
    private AudioSource audioSource;
    private float vineGrowForBubbles = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        app = GameObject.Find("App").GetComponent<App>();

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }


    // on click/touch call this
    private void OnMouseDown()
    {
        //animate button object
        transform.DOShakePosition(0.2f, new Vector3(0.005f, 0.005f, 0.005f), 20);

        // play sound
        audioSource.Play();

        // Donate/ remove bubbles
        DonateNBubbles(cost_for_grow);
        
    }

    public void HighlightButton()
    {
        transform.DOShakeRotation(0.4f, 0.005f, 20);
    }

    public void DonateNBubbles(int n)
    {
        // get number of bubbles
        int numBubbles = PlayerPrefs.GetInt("numBubbles");
        // if no bubbles, return
        if (numBubbles < n)
        {
            Debug.Log("not enough bubbles to donate");
            return;
        }
        else
        {
            app.bubbleController.RemoveNBubbles(n);
            app.displayController.UpdateCarbonDisplay();
            // make vine grow
            app.vineManager.GrowVines(vineGrowForBubbles);
        }
        
    }
}
