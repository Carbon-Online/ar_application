using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DonateManager : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.MainModule psm;
    private AudioSource audioSource;
    private VineManager vineManager;
    private float vineGrowForBubble = 0.1f;

    private SavingsManager savingsManager;

    private ParticleSystem.Particle[] particles;
    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        psm = ps.main;

        savingsManager = GameObject.Find("reset").GetComponent<SavingsManager>();

        audioSource = this.gameObject.GetComponent<AudioSource>();

        vineManager = GameObject.Find("vines").GetComponent<VineManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0.0f, 0.0f, 0.4f, Space.Self);
    }
    private void OnMouseDown()
    {
        //animate button object
        transform.DOShakePosition(0.2f, new Vector3(0.005f, 0.005f, 0.005f), 20);

        // remove one bubble
        particles = new ParticleSystem.Particle[psm.maxParticles];
        // play sound
        audioSource.Play();

        int pNum = ps.GetParticles(particles);
        
        Debug.Log(pNum);
        //remove one particle
        ps.SetParticles(particles[1..]);
        // and safe new numBubbles
        int numBubbles = PlayerPrefs.GetInt("numBubbles");
        // if no bubbles, return
        if (pNum <= 0 && numBubbles <= 0)
        {
            Debug.Log("no bubbles to donate");
            return;
        }
            if (numBubbles > 0)
        {
            PlayerPrefs.SetInt("numBubbles", numBubbles-1);
        }
        // make vine grow
        vineManager.GrowVines(vineGrowForBubble);
        // destroy a bubble
        pNum = ps.GetParticles(particles);
        Debug.Log(pNum);
        // update carbon display
        savingsManager.UpdateCarbonDisplay();
        // Donate something like plant a tree
        Debug.Log("Donation Made");
    }

    public void HighlightButton()
    {
        transform.DOShakeRotation(0.4f, 0.005f, 20);

    }
}
