using UnityEngine;

namespace CollisionEvent
{
    public class ObjectDie : MonoBehaviour, IDie
    {
        public void Die(float hp)
        {
            if (hp <= 0) gameObject.SetActive(false);
        }
    }
}