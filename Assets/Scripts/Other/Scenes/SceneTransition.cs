using Character.Classes;
using UnityEngine;

namespace Other.Scenes
{
    public class SceneTransition : SceneLoader
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Person person) || !person.IsPlayer) return;
            person.Config.SavePoints.Clear();
            LoadScene();
        }
    }
}