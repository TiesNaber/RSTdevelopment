﻿using UnityEngine;
using System.Collections;

public class Weaponrotation : MonoBehaviour
{   

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Input.mousePosition;

        Vector2 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

       
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}