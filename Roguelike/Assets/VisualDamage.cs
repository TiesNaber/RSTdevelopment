using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualDamage : MonoBehaviour {

	[SerializeField]
	bool player;                // boolean to see if it is the player or an enemy
	[SerializeField]
	GameObject blood;           // is the bloodspater particle
	[SerializeField]
	Color blinkColor;           // the color it gets when it blinks

	Color baseColor;            // the color it starts with
	SpriteRenderer myImage;     // your sprite
	

	// Use this for initialization
	void Start () {
		myImage = GetComponent<SpriteRenderer>();
		baseColor = myImage.color;
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			MakeItBlink(player);
		}
	}

	public void MakeItBlink(bool player)
	{
		StartCoroutine(Blink(player));
	}
	
	IEnumerator Blink(bool Player)
	{
		//make it blink twice
		myImage.color = blinkColor;

        Vector3 pos = transform.position;
        GameObject tempHolder = (GameObject)Instantiate(blood, new Vector3(pos.x, pos.y, pos.z - 0.2f), Quaternion.identity);
		Destroy(tempHolder, 1);

        if(!player)
        {
            Destroy(gameObject);
        }
		
		yield return new WaitForSeconds(0.25f);
		myImage.color = baseColor;
	}
}
