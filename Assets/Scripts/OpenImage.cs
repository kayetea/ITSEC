using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenImage: MonoBehaviour{
	public GameObject panel;
	public Texture2D[] imageArray;
	private int currentImage = 0;
	public RawImage rawImage; 

	private GameObject homePrevBtn;

    private GoogleAnalyticsV4 googleAnalytics;


    void Start() {
		//currentImage = 0;
		rawImage.texture = imageArray[currentImage];

        googleAnalytics = GameObject.Find("GAv4").GetComponent<GoogleAnalyticsV4>();
    }

	void Update(){
		if (Input.GetKeyUp("left"))
		{
			Debug.Log ("You swiped left!");
			currentImage++;
			LoopArray();
			rawImage.texture = imageArray[currentImage];
		}
		
		if (Input.GetKeyUp("right"))
		{
			Debug.Log ("You swiped right!");
			currentImage--;
			LoopArray();
			rawImage.texture = imageArray[currentImage];
		}

	}

	//Open Panel
	public void EnablePanel(int buttonImage){
		panel.SetActive(true);
		currentImage = buttonImage;
		rawImage.texture = imageArray[currentImage];

        /*disable previous button
		homePrevBtn = GameObject.Find("HomePrev");
		homePrevBtn.SetActive(false);*/

        Debug.Log(rawImage);

        //googleAnalytics.LogEvent("Open Image", )
	}

	//Close Panel
	public void ClosePanel(){
		panel.SetActive (false);
		//homePrevBtn.SetActive(true);
	}
	

	//Loop Image Array
	private void LoopArray(){
		if (currentImage == imageArray.Length) {
			currentImage = 0;
		}
		
		if (currentImage == -1) {
			currentImage = imageArray.Length - 1;
		}
	}


	//CHECK SWIPES & TAP
	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
		//Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
		//Lean.LeanTouch.OnFingerTap -= OnFingerTap;
	}
	

	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		// Store the swipe delta in a temp variable
		var swipe = finger.SwipeDelta;
		
		if (swipe.x < -Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped left!");
			currentImage++;
			LoopArray();
			rawImage.texture = imageArray[currentImage];

		}
		
		if (swipe.x > Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped right!");
			currentImage--;
			LoopArray();
			rawImage.texture = imageArray[currentImage];
			
		}
	}

}