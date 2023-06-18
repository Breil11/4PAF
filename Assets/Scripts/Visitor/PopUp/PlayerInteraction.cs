using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public float detectionDistance = 2f; // Distance de détection
    public GameObject interactableObject; // Référence à l'objet avec lequel le joueur peut interagir

    private void Update()
    {
        // Vérifier si le joueur est suffisamment proche de l'objet interactable
        if (interactableObject != null && Vector3.Distance(transform.position, interactableObject.transform.position) <= detectionDistance)
        {
            // Charger la nouvelle scène
            SceneManager.LoadScene("DemoScene");
        }
    }
}
