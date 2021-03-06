using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class VineManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] vines;
    private float totalGrow;

    private string grow_tag = "grow";



    // Start is called before the first frame update
    void Start()
    {
        totalGrow = PlayerPrefs.GetFloat("totalGrow");
        GrowVinesInitial(totalGrow);
    }

    // Update is called once per frame
    public void GrowVines(float amount)
    {

        // set totalGrow in player prefs
        totalGrow = PlayerPrefs.GetFloat("totalGrow");
        // clip to max grow
        if(amount + totalGrow > 6)
        {
            amount = 6-totalGrow;
        }
        PlayerPrefs.SetFloat("totalGrow", totalGrow + amount);
        // make them grow
        for (int i = 0; i < vines.Length; i++)
        {
            Material mat_temp = vines[i].GetComponent<MeshRenderer>().material;
            float vine_size_temp = mat_temp.GetFloat(grow_tag);
            float diff = 2 - vine_size_temp;
            if(amount >= diff)
            {
                mat_temp.DOFloat(vine_size_temp + diff, grow_tag, 1f);
                amount -= diff;
            }
            else if(amount > 0)
            {
                mat_temp.DOFloat(vine_size_temp + amount, grow_tag, 1f);
                amount = 0;
                break;
            }
        }
        
    }

    private void GrowVinesInitial(float amount)
    {
        uint i = 0;
        while (amount >= 2)
        {
            vines[i].GetComponent<MeshRenderer>().material.DOFloat(2, grow_tag, 2f);
            amount -= 2f;
            i++;
        }
        // check if there is significant grow amount left
        if(amount > 0.1)
        {
            vines[i].GetComponent<MeshRenderer>().material.DOFloat(amount, grow_tag, 2f);
        }

    }

    public void ResetVines()
    {
        totalGrow = 0;
        PlayerPrefs.SetFloat("totalGrow", 0);
        // make them grow
        for (int i = 0; i < vines.Length; i++)
        {
            Material mat_temp = vines[i].GetComponent<MeshRenderer>().material;
            mat_temp.DOFloat(0, grow_tag, 2f);
        }
    }
}
