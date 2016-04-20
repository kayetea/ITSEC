using UnityEngine;
using System.Collections;
using Vuforia;

public class ReviveVuforia : MonoBehaviour {

	private VuforiaBehaviour Vuforia;


	// Use this for initialization
	void Start () {
		Vuforia = FindObjectOfType<VuforiaBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartTracking() {
		Vuforia.enabled = true;
		ObjectTracker it = TrackerManager.Instance.GetTracker<ObjectTracker>();
		MarkerTracker mt = TrackerManager.Instance.GetTracker<MarkerTracker>();
		CameraDevice.Instance.Start ();
		it.Start ();
		mt.Start ();
	}

	public void StopTracking() {
		Vuforia.enabled = false;
		ObjectTracker it = TrackerManager.Instance.GetTracker<ObjectTracker>();
		MarkerTracker mt = TrackerManager.Instance.GetTracker<MarkerTracker>();
		it.Stop ();
		mt.Stop ();
		CameraDevice.Instance.Stop ();
	}

}
