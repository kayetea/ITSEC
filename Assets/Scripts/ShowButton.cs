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

namespace Vuforia{
	public class ShowButton : MonoBehaviour, ITrackableEventHandler {
		
		private TrackableBehaviour mTrackableBehaviour;

		public GameObject modelUI;
		public GameObject targetModel;

		private PlayButton playButton;

		//private AudioSource modelSFX;

		void Start () {
			modelUI.SetActive(false);

			//modelSFX = targetModel.GetComponent<AudioSource>();

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}

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


			}
			else
			{
				//if image target lost, hide UI
				modelUI.SetActive(false);

				//if playing animation, stop animation, change icon
				playButton = targetModel.GetComponent<PlayButton>();
				if(playButton.firstPress)
					playButton.Clicked();
			}
		}

	}
}