using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class row1 : row
{
    private float randomValue;
    private float timeInterval;
    [SerializeField]
    private row[] rows;
    private float steps;

    

    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        Slot.Buttonpushed += StartRotating;
    }

    private void StartRotating()
    {
    	stoppedSlot = "lol ";
        win=rows[0].win;
    	StartCoroutine("Rotate");

    }

    private IEnumerator Rotate()
    {   
    	rowStopped = false;
    	timeInterval = 0.005f;
        FindObjectOfType<AudioManager>().Play("Giroslot");
        if (rows[0].win==true)
        {
            steps = rows[0].Logo;
        }
        else
        {
            steps = rows[0].RandomLogo();
        }
    	for (int i=0; i<150; i++)
    	{
    		if (transform.position.y <= -13f)
    		{
    			transform.position = new Vector2(transform.position.x,16.25f);
    		}
    		transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(150 * 0.5f))
            {
                timeInterval = 0.008f;
            }
            if (i > Mathf.RoundToInt(150 * 0.95f))
            {
                timeInterval = 0.02f;
            }


    		yield return new WaitForSeconds(timeInterval);
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
        FindObjectOfType<AudioManager>().Play("Finishslot");
    	rowStopped = true;
    }
    private void OnDestroy()
    {
    	Slot.Buttonpushed -= StartRotating;
    }

}