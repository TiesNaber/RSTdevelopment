using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	Vector3 startPos;
	Transform startParent;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
        GameObject.Find("CraftCanvas").transform.GetChild(0).gameObject.SetActive(true);
		itemBeingDragged = gameObject;
		startPos = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = new Vector3(Input.mousePosition.x - 10f, Input.mousePosition.y - 10f, 0);
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
        itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPos;
		}
	}

	#endregion
}
