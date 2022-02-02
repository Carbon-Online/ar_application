using DG.Tweening;
using UnityEngine;
using TMPro;

public class SavingsManager : MonoBehaviour
{
    private ParticleSystem ps;

    private ParticleSystem.MainModule psm;

    private ParticleSystem.Particle[] particles;

    private DonateManager donateManager;

    private TMP_Text carbonDisplay;

    private AudioSource audioSource;

    private int numBubbles;


    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        psm = ps.main;

        donateManager = GameObject.Find("addTree").GetComponent<DonateManager>();

        audioSource = this.gameObject.GetComponent<AudioSource>();
        // emit safed number of bubbles
        numBubbles = PlayerPrefs.GetInt("numBubbles");
        ps.Emit(numBubbles);
        // set carbonDisplay text
        UpdateCarbonDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0.0f, 0.0f, 0.4f, Space.Self);
    }
    private void OnMouseDown()
    {
        numBubbles = PlayerPrefs.GetInt("numBubbles");
        particles = new ParticleSystem.Particle[psm.maxParticles];
        int pNum = ps.GetParticles(particles);
        if (pNum >= psm.maxParticles)
        {
            Debug.Log("you cannot store more than 20KG of carbon. You need to Donate now!");

            // hightlight donate button
            
            donateManager.HighlightButton();
            return;
        }
        //animate button object
        transform.DOShakePosition(0.2f, new Vector3(0.005f, 0.005f, 0.005f), 20);
        //play sound
        audioSource.Play();
        // emit one bubble
        ps.Emit(1);
        // and safe new numBubbles
        PlayerPrefs.SetInt("numBubbles", numBubbles + 1);
        // and update carbon display
        UpdateCarbonDisplay();
        // Donate something like plant a tree
        Debug.Log("Saving Made");
    }

    public void UpdateCarbonDisplay()
    {
        numBubbles = PlayerPrefs.GetInt("numBubbles");
        carbonDisplay = GameObject.Find("carbonDisplay").GetComponent<TMP_Text>();
        carbonDisplay.text = "You have safed \n" +
                                numBubbles.ToString() +
                                " kilogramms \n of carbon.";
    }
}