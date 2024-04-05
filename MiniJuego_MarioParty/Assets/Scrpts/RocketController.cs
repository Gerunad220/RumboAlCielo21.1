using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketMana : MonoBehaviour
{
    [SerializeField]
    private float counter;
    [SerializeField]
    private BarraCombustible combustible;

    public float delayBeforeLaunch = 3f;
    public float victoryHeight;
    private bool launched = false;

<<<<<<< HEAD
    

    
=======
>>>>>>> parent of c234a58 (Cambios en el boton)

    void Start()
    {
        
        Invoke("Launch", delayBeforeLaunch);
    }

    
    void Update()
    {
        combustible = GetComponent<BarraCombustible>();
        victoryHeight = combustible.counter;


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
