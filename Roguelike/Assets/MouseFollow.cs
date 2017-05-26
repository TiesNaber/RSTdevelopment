using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour {

    [SerializeField]
    Texture2D cursorTexture;
    Vector2 hotSpot;
	// Use this for initialization

    // Update is called once per frame
    void Update () {
		if(gameObject.activeSelf)
        {
            hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);

        }
    }

    private void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
