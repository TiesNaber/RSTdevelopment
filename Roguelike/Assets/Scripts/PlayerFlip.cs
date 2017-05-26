using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour {

    public Transform player = null;

	private bool faceRight = true;
	public bool FaceRight
	{
		set
		{
            Debug.Log(faceRight+",  "+ value);
            if (faceRight == value)
				return;
			else
				faceRight = value;
            Flip();
            
				
		}
	}

	void Awake()
    {
        if(!player)
            player = transform;
    }

    void Flip()
    {
        Debug.Log("flip bitch");
        //Flipping the character by changing the scale to negative or postive
        Vector3 theScale = player.localScale;
        theScale.x *= -1;
        player.localScale = theScale;

    }
}
