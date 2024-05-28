using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Items
{
    public class ItemScript : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onItemPickup;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                _onItemPickup.Invoke();

                gameObject.SetActive(false);
            }
        }
    }
}
