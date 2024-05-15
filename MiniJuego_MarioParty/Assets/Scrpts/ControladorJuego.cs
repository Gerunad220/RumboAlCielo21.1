using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public float tiempoMaximo;
    private float tiempoActual;
    private bool tiempoActividado = false;
    public Slider slider;

    public string EscenaGameOver = "EscenaGameOver";


    void Start()
    {
        ActivarTemporizador();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoActividado)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;
        if(tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }

        if (tiempoActual <= 0)
        {
            Debug.Log("Derrota");
            CambiarTemporizador(false);
            SceneManager.LoadScene(EscenaGameOver);
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActividado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador (true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
