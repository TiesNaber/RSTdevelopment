using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour {

    Color baseColor;
    [SerializeField]
    Color selectedColor;

    // Use this for initialization
    void Start () {
        baseColor = transform.GetChild(0).GetComponent<Image>().color;

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        Vector2 dir = Vector2.zero;

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
        if (hit != null && hit.collider != null && hit.collider.tag == "Weapon")
        {
            if(hit.transform.parent == transform.GetChild(0))
            {
                SetWeapon(0, 1);
            }
            else if (hit.transform.parent == transform.GetChild(1))
            {
                SetWeapon(1, 0);
            }
        }
    }

    void SetWeapon(int clicked, int notClicked)
    {
        transform.GetChild(clicked).GetChild(0).GetComponent<WeaponScript>().enabled = true;
        transform.GetChild(clicked).GetComponent<Image>().color = selectedColor;

        if (transform.GetChild(notClicked).childCount > 0)
        {
            transform.GetChild(notClicked).GetChild(0).GetComponent<WeaponScript>().enabled = false;
            transform.GetChild(notClicked).GetComponent<Image>().color = baseColor;
        }
    }
}
