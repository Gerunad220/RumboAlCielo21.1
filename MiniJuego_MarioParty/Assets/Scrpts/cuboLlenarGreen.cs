using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class cuboLlenarGreen : MonoBehaviour
{

    private float currentFillAmount = 0f;
    public float fillSpeed = 0.1f;
    public Image fillImage;

    public float contar = 0f;

   

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

        if (other.gameObject.tag == "cubo")
        {
            Debug.Log("punto");
            contar++;

        }



        //Destroy(gameObject);
        void ShowNextPrompt()
        {
            UnityEngine.Debug.Log("Siguiente");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void GetContar()
    {
        contar= contar;
    }
}
