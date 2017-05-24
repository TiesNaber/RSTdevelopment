using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFeedback : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        DeactivateText();

	}

    public void ActiveText()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateText()
    {
        gameObject.SetActive(false);
    }
	


    
}
