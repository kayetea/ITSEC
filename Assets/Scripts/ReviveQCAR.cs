using UnityEngine;
using System.Collections;
using Vuforia;

public class ReviveQCAR : MonoBehaviour {

	private QCARBehaviour QCAR;


	// Use this for initialization
	void Start () {
		QCAR = FindObjectOfType<QCARBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartTracking() {
		QCAR.enabled = true;
		ObjectTracker it = TrackerManager.Instance.GetTracker<ObjectTracker>();
		MarkerTracker mt = TrackerManager.Instance.GetTracker<MarkerTracker>();
		CameraDevice.Instance.Start ();
		it.Start ();
		mt.Start ();
	}

	public void StopTracking() {
		QCAR.enabled = false;
		ObjectTracker it = TrackerManager.Instance.GetTracker<ObjectTracker>();
		MarkerTracker mt = TrackerManager.Instance.GetTracker<MarkerTracker>();
		it.Stop ();
		mt.Stop ();
		CameraDevice.Instance.Stop ();
	}

}
