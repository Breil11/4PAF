using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public float detectionDistance = 2f; // Distance de d�tection
    public GameObject interactableObject; // R�f�rence � l'objet avec lequel le joueur peut interagir

    private void Update()
    {
        // V�rifier si le joueur est suffisamment proche de l'objet interactable
        if (interactableObject != null && Vector3.Distance(transform.position, interactableObject.transform.position) <= detectionDistance)
        {
            // Charger la nouvelle sc�ne
            SceneManager.LoadScene("DemoScene");
        }
    }
}
