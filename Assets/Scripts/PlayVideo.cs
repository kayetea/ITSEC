using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public string movieName;

	void Start (){
	
	}

	public void PlayM (){
		Debug.Log ("play movie");
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Handheld.PlayFullScreenMovie(movieName, Color.black, FullScreenMovieControlMode.Full, FullScreenMovieScalingMode.AspectFit);
			Debug.Log ("play movie");
        }
    }
}
