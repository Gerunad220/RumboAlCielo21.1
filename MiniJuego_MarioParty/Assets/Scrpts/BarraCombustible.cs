using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

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
        }        
    }
}
