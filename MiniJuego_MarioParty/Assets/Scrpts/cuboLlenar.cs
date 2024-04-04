using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cuboLlenarRed : MonoBehaviour
{

    private float currentFillAmount = 0f;
    public float fillSpeed = 0.1f;
    public Image fillImage;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
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
        //Destroy(gameObject);
        void ShowNextPrompt()
        {
            UnityEngine.Debug.Log("Siguiente");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
