using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    
    void Start()
    {
        Invoke("Reinicio", 3);
    }

    public void Reinicio()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
