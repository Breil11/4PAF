/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50; // Vitesse de d�placement du joueur
    public GameObject weapon; // GameObject de l'arme parent� au joueur
    public GameObject projectilePrefab; // Pr�fabriqu� du projectile


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // R�cup�re la valeur de d�placement horizontal (axe X) du clavier
        float verticalInput = Input.GetAxis("Vertical"); // R�cup�re la valeur de d�placement vertical (axe Z) du clavier

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // Cr�e un vecteur de d�placement en fonction des valeurs r�cup�r�es

        transform.position += movement * speed * Time.deltaTime; // Modifie la position du joueur en fonction du vecteur de d�placement et de la vitesse
        weapon.transform.position += movement * speed * Time.deltaTime; // Modifie la position de l'arme en fonction du vecteur de d�placement et de la vitesse

       
    }
}
*/



using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float mouseSensitivityX = 5f;

    [SerializeField]
    private float mouseSensitivityY = 5f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {

        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;


        if (!CheckCollision(velocity))
        {
            motor.Move(velocity);
        }

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * mouseSensitivityY;

        motor.RotateCamera(cameraRotation);

        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, Mathf.Infinity))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }

    private bool CheckCollision(Vector3 direction)
    {
        float rayDistance = 1f;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Door"))
            {
                return true; 
            }
        }

        return false; 
    }
    
}
