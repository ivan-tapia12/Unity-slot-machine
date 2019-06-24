using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Slot : MonoBehaviour
{
    public static event Action Buttonpushed = delegate{};
    

    [SerializeField]
    private row[] rows;
    [SerializeField]
    private Text winText;

    public bool win;
    public float Logo=0f;

    private string prize;
    private int rand;
    private float randomlogo;

    private bool resultsChecked = false;

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped && !rows[1].rowStopped && !rows[2].rowStopped)
        {
        	prize = " ";
        	winText.enabled = false;

        }
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
        	winText.enabled = true;
        	
        	
        }
        bool Bttn =Input.GetButton("Fire1");
        if (Bttn)
        {
        	if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
    	    {
    		    Buttonpushed();
    	    }
        }
    }
    public void OnClick()
    {
    	if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
    	{
    		Buttonpushed();
    	}
    }
    

}
