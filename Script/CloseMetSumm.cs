using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMetSumm : MonoBehaviour
{    public GameObject Summ;
    public GameObject Button;
    public void OnMouseDown()
    {
        Summ.SetActive(false);
        Button.GetComponent<BoxCollider2D>().enabled = true;


    }
}

