using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaLuigi : MonoBehaviour
{
    public float jumpForce = 3f; // Fuerza del salto de la m�quina
    public int numJumps = 6; // N�mero de saltos que la m�quina debe realizar en las posiciones espec�ficas
    private Rigidbody rb; // Referencia al componente Rigidbody de la m�quina
    private bool hasMoved = false; // Indica si la m�quina ha realizado el movimiento lateral
    private float jumpDelay = 2.5f; // Retraso entre saltos

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody

        // Ajustar la configuraci�n del Rigidbody para evitar rebotes
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Salto inicial en la posici�n especificada
        Jump(new Vector3(-0.12f, 2.46f, -1.97f));
    }

    void Jump(Vector3 position)
    {
        // La m�quina salta en la posici�n especificada
        transform.position = position;
        rb.velocity = Vector3.zero; // Detener cualquier movimiento existente
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Comenzar a saltar en el lugar en la nueva posici�n
        InvokeRepeating("JumpInPlace", 0f, jumpDelay);
    }

    void JumpInPlace()
    {
        // La m�quina salta en el sitio
        rb.velocity = Vector3.zero; // Detener cualquier movimiento existente
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        numJumps--; // Reducir el n�mero de saltos restantes

        // Si se han realizado todos los saltos requeridos, detener el salto
        if (numJumps <= 0)
        {
            CancelInvoke("JumpInPlace");

            // Si la m�quina no ha realizado el movimiento lateral, realizarlo
            if (!hasMoved)
            {
                Move(new Vector3(0.9f, 2.46f, -1.97f));
            }
            else
            {
                // Si la m�quina ya ha realizado el movimiento lateral, detenerse
                StopMoving();
            }
        }
    }

    void Move(Vector3 position)
    {
        // Mover la m�quina a la posici�n especificada
        transform.position = position;
        hasMoved = true;

        // Si la m�quina est� en la segunda posici�n, detener el movimiento lateral y realizar los saltos
        if (position == new Vector3(-0.12f, 2.46f, -1.97f))
        {
            
            numJumps = 5; // Restablecer el n�mero de saltos
            InvokeRepeating("JumpInPlace", 0f, jumpDelay);
        }
    }

    void StopMoving()
    {
        // Detener el movimiento despu�s de completar los saltos en la segunda posici�n
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}