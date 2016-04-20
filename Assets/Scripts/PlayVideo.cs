using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public string movieName;

    private GoogleAnalyticsV4 googleAnalytics;

    void Start (){
        googleAnalytics = GameObject.Find("GAv4").GetComponent<GoogleAnalyticsV4>();
    }

	public void PlayM (){
		Debug.Log ("play movie");
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Handheld.PlayFullScreenMovie(movieName, Color.black, FullScreenMovieControlMode.Full, FullScreenMovieScalingMode.AspectFit);
			Debug.Log ("play movie");

            googleAnalytics.LogEvent("Video", movieName, movieName, 1);
        }
    }
}
