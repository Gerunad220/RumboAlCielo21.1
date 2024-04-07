using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketMana : MonoBehaviour
{
    public float delayBeforeLaunch = 3f;
    public float victoryHeight;
    private bool launched = false;

    public cuboLlenarRed combustible;
    public cuboLlenarGreen comb2;


    void Start()
    {
        
        Invoke("Launch", delayBeforeLaunch);
    }

    
    void Update()
    {
        
        


        if (launched)
        {
            
            transform.Translate(Vector3.up * Time.deltaTime * 10f); 

            if (transform.position.y >= victoryHeight)
            {
                
                SceneManager.LoadScene("EscenaVictoria"); // Asegúrate de cambiar "EscenaVictoria" al nombre de tu escena de victoria
            }
        }
    }

    private void Launch()
    {
        
        launched = true;
        
        UnityEngine.Debug.Log("¡Cohete despegado!");
    }
}
