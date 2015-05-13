using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemsList : MonoBehaviour {

	public GameObject buttonPrefab;
	public GameObject panel;
	int buttonsPerRow = 4;
	
	void Start () {
		InitPanel();
	}

	public void InitPanel ()
	{
		Debug.Log ("Updating items panel.");
		Transform newButton;
		var itemPrefabs = ItemTypeKeeper.main.GetItemPrefabs();
		for(int i = 0; i < itemPrefabs.Count; i++)
		{
			newButton = (Instantiate(buttonPrefab) as GameObject).transform;
			newButton.SetParent(panel.transform);
			var prefabSprite = itemPrefabs[i].GetComponent<SpriteRenderer>().sprite;
			newButton.transform.name = itemPrefabs[i].transform.name + " button";
			newButton.localScale = new Vector3(1f,1f,1f);

			//set the button sprite to the item sprite
			foreach (Transform child in newButton.transform) {
				if(child.name == "Image")
				{
					Image buttonImage = child.GetComponent<Image>() as Image;
					buttonImage.sprite = prefabSprite;
					break;
				}
			}
			
			//place the button in its spot on the panel
//			var rectTransform = newButton.GetComponent<RectTransform>();
//			float buttonSize = 1f;
//			float buttonSeparation = 35f;
//			rectTransform.offsetMin = new Vector2(
//				((buttonSize+buttonSeparation)*(i%buttonsPerRow)) + buttonSeparation/2				
//				,-2-(i-(i%buttonsPerRow)));
//			rectTransform.offsetMax = new Vector2(
//				((buttonSize+buttonSeparation)*(i%buttonsPerRow)) + (buttonSize+buttonSeparation/2)	
//				,-1-(i-(i%buttonsPerRow)));
//			rectTransform.anchorMin = new Vector2(0,1);
//			rectTransform.anchorMax = new Vector2(0,1);
			
			
			//set the prefab for the button
			//ConstructionPanelButton newButtonScript = newButton.GetComponent<ConstructionPanelButton>() as ConstructionPanelButton;
			//newButtonScript.buildingPrefab = buildingPrefabs[i];
		}
	}


}
