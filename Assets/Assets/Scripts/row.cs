using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class row : MonoBehaviour
{

    public bool rowStopped;
    public string stoppedSlot;
    public bool win;
    public float Logo;
    private float randomlogo;
    private int rand;
    Slot mySlot = new Slot();

    public float Absolute(float number)
    {
    	if (number < 0) 
    	{
    		number = number * (-1f);
    		return number;
    	}
    	else 
    	{
    		return number;
    	}
    }
    public float RandomLogo()
    {
    	//La funcion te regresa la posición de uno de los 7 logos aleatorios
    	rand = UnityEngine.Random.Range(1, 8);
    	switch (rand)
    	{
    		case 1:
    		     randomlogo = -9f;
    		     break;
    		case 2:
    		     randomlogo = -5f;
    		     break;
    		case 3:
    		     randomlogo = -0.75f;
    		     break;
    		case 4:
    		     randomlogo = 3.75f;
    		     break;
    		case 5:
    		     randomlogo = 8f;
    		     break;
    		case 6:
    		     randomlogo = 12f;
    		     break;
    		case 7:
    		     randomlogo = -13f;
    		     break;
    	}
    	return randomlogo;
    }
    void Start()
    {
        Slot.Buttonpushed += House;
    }
    private void House()
    {
    	rand=UnityEngine.Random.Range(1, 4);
    	switch (rand)
    	{
   			case 1:
   			     win=true;
   			     break;
   			default:
    		     win=false;
    		     break;
    	}
   		if (win==true)
    	{
   			Logo=RandomLogo();

    	}
   		else
   		{
   			win = false;
   		}
    } 
}
