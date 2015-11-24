/*------------------------------------------------------
Project: AR_test
Program: ShowButton.cs
Author: Katelyn Godfrey

Description: When Image Target is tracked, show the 
appropriate UI. When target is lost, hide UI.

Updated: 05/28/2015 
------------------------------------------------------

ADD TO EACH IMAGE TARGET. ADD ASSOCIATED UI BUTTON GAME OBJECT
TO THE "Anim Button" VARIABLE.

------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Vuforia{
	public class ShowButton : MonoBehaviour, ITrackableEventHandler {
		
		private TrackableBehaviour mTrackableBehaviour;

		public GameObject modelUI;
		public GameObject targetModel;
		/*private int stackOrder;
		private List<Vector2> uiDimensions = new List<Vector2>();
		private Vector2 stackOrder1 = new Vector2(1920, 250);
		private Vector2 stackOrder2 = new Vector2(1920, 700);
		private Vector3 stackOrder3 = new Vector2(1920, 1200);
		private int visibleBars = 0;*/

		private PlayButton playButton;

		//private AudioSource modelSF;

		void Start () {
			modelUI.SetActive(false);

			//modelSFX = targetModel.GetComponent<AudioSource>();
		
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}

			//set dimeninsions up
			/*uiDimensions.Add(stackOrder1);
			uiDimensions.Add(stackOrder2);
			uiDimensions.Add(stackOrder3);*/

		}

		void Update(){
			//if visible bars >2 check if that's changed
			// if visibles bars previous is larger than current, shift everything up one
			//if there's only 1 item, make sure it's zeroed out

			/*if(visibleBars > 1)
			{
				if (GameObject.FindGameObjectsWithTag("UI-bar").Length == 0)
				{
					visibleBars = 0;
				}
				else if(GameObject.FindGameObjectsWithTag("UI-bar").Length == 1)
				{
					modelUI.GetComponent<RectTransform>().sizeDelta = uiDimensions[0];
				}
				else if(GameObject.FindGameObjectsWithTag("UI-bar").Length < visibleBars)
				{
					modelUI.GetComponent<RectTransform>().sizeDelta = uiDimensions[stackOrder-2];
				}
			}*/
		}
		
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			    newStatus == TrackableBehaviour.Status.TRACKED)
			{
				//if tracked, show UI 
				modelUI.SetActive(true);

				//check if other UIs are active, adjust accordingly
				/*visibleBars = GameObject.FindGameObjectsWithTag("UI-bar").Length;

				if (visibleBars == 2)
				{
					stackOrder = 2;
					modelUI.GetComponent<RectTransform>().sizeDelta = uiDimensions[stackOrder-1];
				}
				if (visibleBars == 3)
				{
					stackOrder = 3;
					modelUI.GetComponent<RectTransform>().sizeDelta = uiDimensions[stackOrder-1];
				}*/
			}
			else
			{
				//if image target lost, hide UI
				modelUI.SetActive(false);

				//reset UI location
				//modelUI.GetComponent<RectTransform>().sizeDelta = stackOrder1;

				//if playing animation, stop animation, change icon
				playButton = targetModel.GetComponent<PlayButton>();
				if(playButton.firstPress)
					playButton.Clicked();
			}
		}

	}
}