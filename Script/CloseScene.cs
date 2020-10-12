using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseScene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
}
