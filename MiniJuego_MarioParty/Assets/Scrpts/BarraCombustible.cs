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

    private float currentFillAmount = 0f;


    void Start()
    {
        fillButton.onClick.AddListener(FillBar);
    }

    
    void FillBar()
    {
        if(currentFillAmount < 1f)
        {
            currentFillAmount += fillSpeed * Time.deltaTime;

            currentFillAmount = Mathf.Clamp01(currentFillAmount);

            fillImage.fillAmount = currentFillAmount;

            if(currentFillAmount >= 1f)
            {
                ShowNextPrompt();            
            }
        }        
    }

    void ShowNextPrompt()
    {
        UnityEngine.Debug.Log("Siguiente");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
