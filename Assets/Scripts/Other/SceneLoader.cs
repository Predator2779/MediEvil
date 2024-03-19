using Character.Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Other
{
    public class SceneLoader : MonoBehaviour/////
    {
        [SerializeField] private string _loadScene;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Person person) || !person.IsPlayer) return;
            person.Data.SavePoints = null;
            LoadScene();
        }

        private void LoadScene() => SceneManager.LoadScene(_loadScene);
    }
}