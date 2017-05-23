using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionExpansionScript : MonoBehaviour {
    public Light illuminate;
    bool canExpand = true;

    private void Start()
    {
        illuminate = GetComponent<Light>();
    }
   
    ///<summary>
    ///If you press T the vision of the player will increase unitll it reaches a
    ///certain value. NOTE: Change pressing T to when enemy is killed
    ///</summary>
        void Update () {
            
        if (Input.GetKeyDown(KeyCode.T) && canExpand == true)
        {
            illuminate.range += 10;
            illuminate.intensity -= 0.1F;
            if(illuminate.intensity <=2.1)
            {
                canExpand = false;
            }
        }
	}
}
