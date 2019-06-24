using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class row3 : row
{
    private float randomValue;
    private float timeInterval;
    private float steps;
    [SerializeField]
    private row[] rows;

    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        Slot.Buttonpushed += StartRotating;
    }

    private void StartRotating()
    {
    	stoppedSlot = " ";
    	StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
    	rowStopped = false;
    	timeInterval = 0.005f;
        if (rows[0].win==true)
        {
            steps = rows[0].Logo;
        }
        else
        {
            steps = rows[0].RandomLogo();
        }
    	for (int i=0; i<290; i++)
    	{
    		if (transform.position.y <= -13f)
    		{
    			transform.position = new Vector2(transform.position.x,16.25f);
    		}
    		transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            if (i > Mathf.RoundToInt(290 * 0.5f))
            {
                timeInterval = 0.008f;
            }
            if (i > Mathf.RoundToInt(290 * 0.95f))
            {
                timeInterval = 0.02f;
            }
            
    		yield return new WaitForSeconds(timeInterval);
    	} 
    	if (win == true)
    	{
    		randomValue = Absolute((0f - transform.position.y)/0.25f);
    	}
    	else
    	{
    	    randomValue = Absolute((0f - transform.position.y)/0.25f);
    	}
    	while (transform.position.y != steps)
    	{
    		if (transform.position.y <= -13f)
    		{
    			transform.position = new Vector2(transform.position.x,16.25f);
            }
    		transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

    		yield return new WaitForSeconds(timeInterval);
    	}
        FindObjectOfType<AudioManager>().Stop("Giroslot");
        FindObjectOfType<AudioManager>().Play("Finishslot");
    	rowStopped = true;
    }
    private void OnDestroy()
    {
    	Slot.Buttonpushed -= StartRotating;
    }

}
