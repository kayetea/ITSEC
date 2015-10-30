using UnityEngine;
using System.Collections;

public class LoadInfo : MonoBehaviour {

	public PlayVideo playVideoInstance;
	public GameObject infoObjToLoad;
	public Material objMaterial;

	void Start(){
		playVideoInstance = GetComponent<PlayVideo>();
		objMaterial.SetColor("_OutlineColor", Color.green);

	}
	
	// Activates when object is clicked
	void OnMouseDown(){
		Debug.Log ("enter on mouse down");

		//if a video element is attached, play the video
		if(playVideoInstance && !infoObjToLoad.activeInHierarchy)
		{
			playVideoInstance.PlayM();
		}

		//load info
		infoObjToLoad.GetComponent<MediaButtonToggles>().ToggleVisibility(infoObjToLoad);

		//Debug.Log (this.GetComponent<Renderer>().material);
		//objMaterial.SetColor("_OutlineColor", Color.magenta);

		if (objMaterial.GetColor("_OutlineColor") == Color.green)
		{
			objMaterial.SetColor("_OutlineColor", Color.magenta);
		}
		else if (objMaterial.GetColor("_OutlineColor") == Color.magenta)
		{
			objMaterial.SetColor("_OutlineColor", Color.green);
		}

	}
}
