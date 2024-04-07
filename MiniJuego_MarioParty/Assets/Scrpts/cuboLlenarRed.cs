using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cuboLlenar : MonoBehaviour
{

    private float currentFillAmount = 0f;
    public float fillSpeed = 0.1f;
    public Image fillImage;

    public static float counter { get; set; }




    private void OnTriggerEnter(Collider other)
    {
        if (currentFillAmount < 1f)
        {
            currentFillAmount += fillSpeed * Time.deltaTime;

            currentFillAmount = Mathf.Clamp01(currentFillAmount);

            fillImage.fillAmount = currentFillAmount;

           
        }
        if (other.gameObject.tag == "cubo")
        {
            Debug.Log("punto");
            

        }

    }
}
