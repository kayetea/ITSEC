using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour {

	public GameObject currentScreen;
	public GameObject newScreen;


	void Start () {
		//start with 3d content
		GameObject instance = this.Instantiate(Resources.Load("ContentHolders/3dContent", typeof(GameObject))) as GameObject;
		instance.transform.SetParent (this.transform, false);
	}

	public void ChangeContent(string screenName){
		//destroy all current content
		foreach (Transform child in this.transform)
		{
			GameObject.Destroy (child.gameObject);

			//if model is active, hide it!
		}

		//add screenName with contentholder
		screenName = "ContentHolders/" + screenName;

		//load called content
		GameObject instance = this.Instantiate(Resources.Load(screenName, typeof(GameObject))) as GameObject;
		instance.transform.SetParent (this.transform, false);

	}

	public void ChangeButtonColors(GameObject button){
		//resets all buttons
		foreach(Transform child in GameObject.Find("Canvas/PageBar").transform)
		{
			if(child.GetComponent<Image>().color.a > 0)
			{
				Color resetColor = child.GetComponent<Image>().color;
				resetColor.a = 0;
				child.GetComponent<Image>().color = resetColor;
			}
		}
		//change the selected one
		Color resetColor2 = button.GetComponent<Image>().color;
		resetColor2.a = 1;
		button.GetComponent<Image>().color = resetColor2;
	}

}
