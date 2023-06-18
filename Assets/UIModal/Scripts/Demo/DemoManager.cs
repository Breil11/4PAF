namespace Gravitons.UI.Modal
{
    using UnityEngine.UI;
    using UnityEngine;

    /// <summary>
    /// Manages the UI in the demo scene
    /// </summary>
    public class DemoManager : MonoBehaviour
    {
        public Button button;
        public Button button2;
        public Image image;

        private void Start()
        {
            button.onClick.AddListener(ShowModal);
            button2.onClick.AddListener(ShowModalWithCallback);
        }

        /// <summary>
        /// Show a simple modal
        /// </summary>
        private void ShowModal()
        {
            ModalManager.Show("Note", "Merci de votre réponse", new[] { new ModalButton() { Text = "OK" } });
        }

        /// <summary>
        /// Shows a modal with callback
        /// </summary>
        private void ShowModalWithCallback()
        {
            ModalManager.Show("Open Website", "Open the website in a browser",
                new[] { new ModalButton() { Text = "YES", Callback = OpenWebsite }, new ModalButton() { Text = "NO" } });
        }

        /// <summary>
        /// Open the website in a browser
        /// </summary>
        private void OpenWebsite()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                // Open the link in a new browser window
                Application.ExternalEval("window.open('http://localhost:5082/swagger/index.html','_blank')");
            }
            else
            {
                // Open the link in the system's default browser
                Application.OpenURL("http://localhost:5082/swagger/index.html");
            }
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(ShowModal);
            button2.onClick.RemoveListener(ShowModalWithCallback);
        }
    }
}
