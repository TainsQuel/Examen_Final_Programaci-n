using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_Character_Controller : MonoBehaviour
{
    public float HorizontalMove;
    public float VerticalMove;
    public float MoveSpeed;
    public CharacterController Character;
    private Vector3 CharacterInput;

    private Vector3 CharacterDirection;

    public Camera MainCamera;
    private Vector3 CamForward;
    private Vector3 CamRight;

    // Start is called before the first frame update
    void Start()
    {
        // Llama al CharacterController del object al que está asignado el script
        Character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Indica a que son iguales las variables Horizontal y Vertical

        HorizontalMove = Input.GetAxis("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");

        // Le indica al Character que direccion tiene que tomar en base a la camara
        CharacterDirection = CharacterInput.x * CamRight + CharacterInput.z * CamForward;

        // Nueva funcion para gestionar el movimiento de la camara
        camDirection();

        // Limita la velocidad maxima del jugador
        CharacterInput = new Vector3(HorizontalMove, 0, VerticalMove);
        CharacterInput = Vector3.ClampMagnitude(CharacterInput, 1);

        // Multiplica el valor del vector3 CharacterInput por el valor de la variable MoveSpeed para poder controlar la velocidad del PJ
        Character.Move(CharacterDirection * MoveSpeed * Time.deltaTime);

        // Le indica al Character que, si está en moviendo, gire hacia donde mira la cámara
        if (CharacterInput.magnitude > 0.01f)
        {
            Vector3 lookDirection = MainCamera.transform.forward;
            lookDirection.y = 0f;
            lookDirection.Normalize();

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }

        // Funcion camDirection
        void camDirection()
        {
            // Guarda la direccion adelante y derecha de la camara
            CamForward = MainCamera.transform.forward;
            CamRight = MainCamera.transform.right;

            // Limita el eje Y de la camara para que no se mueva de arriba a abajo
            CamForward.y = 0;
            CamRight.y = 0;

            // Nos devuelve el valor normalizado de las variables(eso es bueno :D)
            CamForward = CamForward.normalized;
            CamRight = CamRight.normalized;
        }
    }
}
