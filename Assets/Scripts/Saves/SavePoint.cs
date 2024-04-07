using Character.Classes;
using Character.ComponentContainer;
using Other;
using UnityEngine;

namespace Saves
{
    [RequireComponent(typeof(SpriteChanger))]
    public class SavePoint : MonoBehaviour
    {
        private SpriteChanger _changer;

        private void Start() => _changer = GetComponent<SpriteChanger>(); 

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PersonContainer person) || !person.IsPlayer) return;
            
            AddPoint(person, transform);
            _changer.ChangeSprite();
        }

        private void AddPoint(PersonContainer personContainer, Transform point)
        {
            if (personContainer.Config.SavePoints != null && 
                !personContainer.Config.SavePoints.Contains(point)) 
                personContainer.Config.SavePoints.Add(point);
        }
    }
}