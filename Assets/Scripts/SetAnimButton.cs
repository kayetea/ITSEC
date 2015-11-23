using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetAnimButton : MonoBehaviour {

	private GameObject modelHolder;
	public string animName;
	public MediaButtonToggles toggleScript;

	// Use this for initialization
	void Start () {
		modelHolder = GameObject.Find ("ModelHolder");

		if(modelHolder.transform.GetChild(0).name == "GameObject")
		{
			toggleScript = modelHolder.transform.GetChild(0).transform.GetChild(0).GetComponent<MediaButtonToggles>() as MediaButtonToggles;
		}
		else{
			toggleScript = modelHolder.transform.GetChild(0).GetComponent<MediaButtonToggles>() as MediaButtonToggles;
		}

		Debug.Log(toggleScript);
		this.GetComponent<Button>().onClick.AddListener( () => {toggleScript.ToggleAnimation(animName); });
		this.GetComponent<Button>().onClick.AddListener( () => {MoveTriangle();});
	}

	public void MoveTriangle()
	{
		//clear all triangles
		foreach (Transform child in GameObject.Find ("AnimBar").transform)
		{
			if (child.GetChild(1).GetComponent<Image>().color.a > 0)
			{
				Color resetColor = child.GetChild(1).GetComponent<Image>().color;
				resetColor.a = 0.1f;
				resetColor.r = 1;
				child.GetChild(1).GetComponent<Image>().color = resetColor;
			}
		}
		//mark current
		Color resetColor2 = this.transform.GetChild(1).GetComponent<Image>().color;
		resetColor2.a = 1;
		this.transform.GetChild(1).GetComponent<Image>().color = resetColor2;
	}

}
