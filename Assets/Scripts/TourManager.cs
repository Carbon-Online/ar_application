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
        app.uiController.Alert("Start the CO2NLINE Tour.", "start",
            () => {
            if (!app.model_tracked)
                {
                    app.uiController.Alert("Point the device' rear camera to the artifact on the wall.",
                        "ok", () => { });
                }
                else
                {
                	app.Reset();
                    Debug.Log("starttour(): second case");
                    app.tourUIController.UpdateTourUI(
                        "For each daily saving, you get a bubble.",
                        DayOne
                        );
                }
            });
    }

    public void DayOne()
    {
        DOTween.To(x => app.uiController.dayBar.value = x, 0, 100, 2f)
                .OnComplete(() => {
                    app.uiController.IncrementDayCount();
                    app.savingsManager.EmitNBubbles(1);
                    app.tourUIController.UpdateTourUI(
                        "You'll get many bubbles over time if you keep saving.",
                            StartDayTwoToTen
                        );
                });
    }

    // coroutine blueprint for one day
    IEnumerator AnimateOneDay(float duration, int bubbleCount)
    {
        
        DOTween.To(x => app.uiController.dayBar.value = x, 0, 100, duration)
               .OnComplete(() => {
                   app.uiController.IncrementDayCount();
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
        yield return new WaitForSeconds(1f);
        app.tourUIController.UpdateTourUI(
                        "Donate if you have enough bubbles safed.",
                        () => {
                            app.donateManager.DonateNBubbles(10);
                            StartFinalStep();
                            }
                        );
    }

    IEnumerator DayTenToHundred()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 90; i++)
        {
            yield return StartCoroutine(AnimateOneDay(0.1f, 1)); //Mathf.RoundToInt(Random.Range(0,3))
        }
        app.tourUIController.UpdateTourUI(
                        "You safed a lot, donate again.",
                        () => {
                            app.donateManager.DonateNBubbles(25);
                            ShowEndOfTour();
                        }
                        );
    }

    IEnumerator FinalStep()
    {
        yield return new WaitForSeconds(2);
        app.tourUIController.UpdateTourUI(
            "Do you see the change of the digital artifact?",
            StartDayTenToHundred
            );
    }

    IEnumerator EndOfTour()
    {
        yield return new WaitForSeconds(2);
        app.tourUIController.UpdateTourUI(
            "This was the tour. Thank you for your interest.",
            StartTour
            );
        RestartTour();
    }

    IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(10);
        app.tourUIController.UpdateTourUI(
            "The Tour will be restarted now...",
            () => { }
            );
        yield return new WaitForSeconds(2);
        StartTour();
    }
    public void StartDayTwoToTen()
    {
        StartCoroutine(DayTwoToTen());
    }

    public void StartDayTenToHundred()
    {
        StartCoroutine(DayTenToHundred());
    }

    public void StartFinalStep()
    {
        StartCoroutine(FinalStep());
    }

    public void ShowEndOfTour()
    {
        StartCoroutine(EndOfTour());
    }

    public void RestartTour()
    {
        StartCoroutine(RestartTimer());
    }
}
