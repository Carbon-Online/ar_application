using DG.Tweening;
using UnityEngine;

public class SavingsManager : MonoBehaviour
{
    private App app;

    private AudioSource audioSource;

    private int numBubbles;


    // Start is called before the first frame update
    void Start()
    {
        app = GameObject.Find("App").GetComponent<App>();
        audioSource = this.gameObject.GetComponent<AudioSource>(); 
    }

 
    private void OnMouseDown()
    {
        
        //animate button object
        transform.DOShakePosition(0.2f, new Vector3(0.005f, 0.005f, 0.005f), 20);
        //play sound
        audioSource.Play();
        
        // in production this will not be a button but be called every night
        // when we know, what the user safed
        EmitNBubbles(1);
    }


    public void EmitNBubbles(int n)
    {
        bool success = app.bubbleController.AddNBubbles(n);

        if (success)
        {
            app.displayController.UpdateCarbonDisplay();
        }
        else
        {
            // highlight the donation button
            app.donateManager.HighlightButton();
        }
    }
}