﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);  
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 101f);
    }
}
