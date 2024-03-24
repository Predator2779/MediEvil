using Character.Classes;
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
            if (!other.TryGetComponent(out Person person) || !person.IsPlayer) return;
            
            AddPoint(person, transform);
            _changer.ChangeSprite();
        }

        private void AddPoint(Person person, Transform point)
        {
            if (person.Data.SavePoints != null && 
                !person.Data.SavePoints.Contains(point)) 
                person.Data.SavePoints.Add(point);
        }
    }
}