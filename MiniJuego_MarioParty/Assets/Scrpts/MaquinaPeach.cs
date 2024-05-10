using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaPeach : MonoBehaviour
{
    public float jumpForce = 3f; // Fuerza del salto de la m�quina
    private Rigidbody rb; // Referencia al componente Rigidbody de la m�quina
    private bool hasMoved = false; // Indica si la m�quina ha realizado el movimiento lateral
    private float jumpDelay = 2.5f; // Retraso entre saltos
    private int totalJumps; // N�mero total de saltos que la m�quina debe realizar
    private int jumpsRemaining; // N�mero de saltos restantes

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody

        // Ajustar la configuraci�n del Rigidbody para evitar rebotes
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Establecer el n�mero total de saltos y realizar el primer salto
        totalJumps = 6;
        jumpsRemaining = totalJumps;
        Jump(new Vector3(6.41f, 2.27f, -1.85f));
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
        jumpsRemaining--; // Reducir el n�mero de saltos restantes

        // Si se han realizado todos los saltos requeridos, detener el salto
        if (jumpsRemaining <= 0)
        {
            CancelInvoke("JumpInPlace");

            // Si la m�quina no ha realizado el movimiento lateral, realizarlo
            if (!hasMoved)
            {
                Move(new Vector3(7.57f, 2.27f, -1.85f));
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

        // Si la m�quina est� en la segunda posici�n, iniciar el ciclo de saltos
        if (position == new Vector3(7.57f, 2.27f, -1.85f))
        {
            jumpsRemaining = totalJumps;
            InvokeRepeating("JumpInPlace", jumpDelay, jumpDelay);
        }
    }

    void StopMoving()
    {
        // Detener el movimiento despu�s de completar los saltos en la segunda posici�n
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
