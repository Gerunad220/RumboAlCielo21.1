using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinLlenado : MonoBehaviour
{

    void Start()
    {
        Invoke("LoadVuelo", 3);
    }


    public void LoadVuelo()
    {
        SceneManager.LoadScene("Vuelo");
    }
}
