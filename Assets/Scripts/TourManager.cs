using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TourManager : MonoBehaviour
{
    private App app;

    // Start is called before the first frame update
    void Start()
    {
        app = GameObject.Find("App").GetComponent<App>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTour()
    {

        app.uiController.Alert("Start the interactive Tour.", "start",
            () => {

                if (!app.model_tracked)
                {
                    app.uiController.Alert("Point the device' rear camera to the artifact on the wall.",
                        "ok", () => { });
                }
                else
                {
                    app.vineManager.ResetVines();
                    app.savingsManager.ResetSavings();
                    app.tourUIController.UpdateTourUI(
                        "Every day this app will show new bubbles of CO2.",
                        "okay",
                            DayOne
                        );
                }
            });
    }

    public void DayOne()
    {
        DOTween.To(x => app.uiController.dayBar.value = x, 0, 100, 2f)
                .OnComplete(() => {
                    app.savingsManager.EmitNBubbles(2);
                    app.tourUIController.UpdateTourUI(
                        "You'll get many bubbles over time.",
                        "show me!",
                            StartDayTwoToTen
                        );
                });
    }

    // coroutine blueprint for one day
    IEnumerator AnimateOneDay(float duration, int bubbleCount)
    {
        
        DOTween.To(x => app.uiController.dayBar.value = x, 0, 100, duration)
               .OnComplete(() => {
                   app.savingsManager.EmitNBubbles(bubbleCount);
               });
        yield return new WaitForSeconds(duration);
    }

    IEnumerator DayTwoToTen()
    {
        int[] tenDaysBubbleCount = new int[] { 1, 2, 1, 3, 2, 1, 4, 2, 1, 3 };
        for (int i = 0; i < tenDaysBubbleCount.Length; i++)
        {
            yield return StartCoroutine(AnimateOneDay(1f, tenDaysBubbleCount[i]));
        }
        app.tourUIController.UpdateTourUI(
                        "Donate if you have enough bubbles safed.",
                        "Donate now!",
                        () => { app.donateManager.DonateNBubbles(10); }
                        );

    }
    public void StartDayTwoToTen()
    {
        StartCoroutine(DayTwoToTen());
    }
}
