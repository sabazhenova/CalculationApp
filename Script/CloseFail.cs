using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloseFail : MonoBehaviour
{
    public GameObject Fail;
    public void OnMouseDown()
    {
        Fail.SetActive(false);
    }
}
