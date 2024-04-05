using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraCombustible : MonoBehaviour
{

    public Image fillImage;
    public float fillSpeed = 0.1f;
    public Button fillButton;

    public float counter = 0f;

    private float currentFillAmount = 0f;

<<<<<<< HEAD
    

=======
>>>>>>> parent of c234a58 (Cambios en el boton)

    void Start()
    {
        fillButton.onClick.AddListener(FillBar);
        counter = counter + 1f;
    }


    void FillBar()
    {
        if (currentFillAmount < 1f)
        {
            currentFillAmount += fillSpeed * Time.deltaTime;

            currentFillAmount = Mathf.Clamp01(currentFillAmount);

            fillImage.fillAmount = currentFillAmount;

            if (currentFillAmount >= 1f)
            {
                ShowNextPrompt();
            }
        }
    }

<<<<<<< HEAD
    

=======
>>>>>>> parent of c234a58 (Cambios en el boton)
    void ShowNextPrompt()
    {
        UnityEngine.Debug.Log("Siguiente");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
<<<<<<< HEAD


  
=======
>>>>>>> parent of c234a58 (Cambios en el boton)
}
