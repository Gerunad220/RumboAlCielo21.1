using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaLuigi : MonoBehaviour
{
    public float jumpForce = 3f; // Fuerza del salto de la máquina
    public int numJumps = 6; // Número de saltos que la máquina debe realizar en las posiciones específicas
    private Rigidbody rb; // Referencia al componente Rigidbody de la máquina
    private bool hasMoved = false; // Indica si la máquina ha realizado el movimiento lateral
    private float jumpDelay = 2.5f; // Retraso entre saltos

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody

        // Ajustar la configuración del Rigidbody para evitar rebotes
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Salto inicial en la posición especificada
        Jump(new Vector3(-0.12f, 2.46f, -1.97f));
    }

    void Jump(Vector3 position)
    {
        // La máquina salta en la posición especificada
        transform.position = position;
        rb.velocity = Vector3.zero; // Detener cualquier movimiento existente
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Comenzar a saltar en el lugar en la nueva posición
        InvokeRepeating("JumpInPlace", 0f, jumpDelay);
    }

    void JumpInPlace()
    {
        // La máquina salta en el sitio
        rb.velocity = Vector3.zero; // Detener cualquier movimiento existente
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        numJumps--; // Reducir el número de saltos restantes

        // Si se han realizado todos los saltos requeridos, detener el salto
        if (numJumps <= 0)
        {
            CancelInvoke("JumpInPlace");

            // Si la máquina no ha realizado el movimiento lateral, realizarlo
            if (!hasMoved)
            {
                Move(new Vector3(0.9f, 2.46f, -1.97f));
            }
            else
            {
                // Si la máquina ya ha realizado el movimiento lateral, detenerse
                StopMoving();
            }
        }
    }

    void Move(Vector3 position)
    {
        // Mover la máquina a la posición especificada
        transform.position = position;
        hasMoved = true;

        // Si la máquina está en la segunda posición, detener el movimiento lateral y realizar los saltos
        if (position == new Vector3(-0.12f, 2.46f, -1.97f))
        {
            
            numJumps = 5; // Restablecer el número de saltos
            InvokeRepeating("JumpInPlace", 0f, jumpDelay);
        }
    }

    void StopMoving()
    {
        // Detener el movimiento después de completar los saltos en la segunda posición
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}