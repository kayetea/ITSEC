/*------------------------------------------------------
Project: AR_test
Program: UpdateCell.cs
Author: Katelyn Godfrey

Description: Change UI button based on if the animation
is playing or not to a pause or play icon.

Updated: 05/28/2015 
------------------------------------------------------

ADD TO EACH UI BUTTON. 

TELL ON CLICK TO RUN UpdateCell.UpdateText

------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateCell : MonoBehaviour {

	//private string text;
	private Image playButtonImg;
	private int pressCount;
	public Sprite playImg;
	public Sprite pauseImg;

	// Use this for initialization
	void Start () {
	}
	
	public void UpdateText()
	{
		pressCount++;

		//Text text = GetComponentInChildren<Text>();
		playButtonImg = GetComponentInChildren<Image>();

		if(pressCount % 2 !=0)
			//text.text = "Pause";
			playButtonImg.overrideSprite = pauseImg;
		else
			//text.text = "Play";
			playButtonImg.overrideSprite = playImg;
		
	}
}
