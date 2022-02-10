using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.MainModule psm;
    private ParticleSystem.Particle[] particles;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        psm = ps.main;
        InitializeBubbles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddNBubbles(int n)
    {
        int numBubbles = PlayerPrefs.GetInt("numBubbles");

        if (numBubbles + n > psm.maxParticles)
        {
            Debug.Log("you cannot store more than 20KG of carbon."
                        + "You need to Donate now!");
            return false;
        }
        //emit n bubbles and return success
        ps.Emit(n);
        // safe new numBubbles
        PlayerPrefs.SetInt("numBubbles", numBubbles + n);
        return true;
    }

    public void RemoveNBubbles(int n)
    {
        // get number of bubbles
        int numBubbles = PlayerPrefs.GetInt("numBubbles");
        // if not enough bubbles, return
        if (numBubbles < n)
        {
            Debug.Log("Cannot donate " + n.ToString() + " Bubbles.");
            return;
        }
        // create particle array
        particles = new ParticleSystem.Particle[psm.maxParticles];

        // get particles
        ps.GetParticles(particles);

        //remove the first n particles
        ps.SetParticles(particles[n..]);

        // and safe new numBubbles 
         PlayerPrefs.SetInt("numBubbles", numBubbles - n);
        
    }

    public void RelocateBubbles()
    {
        int numBubbles = PlayerPrefs.GetInt("numBubbles");
        RemoveNBubbles(numBubbles);
        AddNBubbles(numBubbles);
    }

    // used to emit bubbles on augmentation start
    public void InitializeBubbles()
    {
        int numBubbles = PlayerPrefs.GetInt("numBubbles");
        ps.Emit(numBubbles);
    }

    public void ResetBubbles()
    {
        // set num bubbles to 0
        PlayerPrefs.SetInt("numBubbles", 0);

        // clear particle system
        ps.Clear();
    }
}
