using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {

	public static Inventory instance = null;
    private Transform inventoryUI;
    private List<GameObject> inventoryItems = new List<GameObject>();



    public void Start(){
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);	

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(transform.gameObject);

        inventoryUI = transform.GetChild(2);

        StartCoroutine(ShowUI());
    }

	public void SetSlots(){
		int j = 0;
		for (int i = 0; i < inventoryUI.childCount; i++) {
			if (inventoryUI.GetChild (i).childCount == 0) {
				Instantiate(inventoryItems [j], inventoryUI.GetChild(i));
				j++;
			}
		}
	}

	public void SetNewSlot(GameObject item){
		for (int i = 0; i < inventoryUI.childCount; i++) {
			if (inventoryUI.GetChild (i).childCount == 0) {
				item.transform.SetParent (inventoryUI.GetChild (i));
				inventoryItems.Add (item);
				return;
			}
		}
	}

    IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Canvas>().enabled = true;
    }
}
