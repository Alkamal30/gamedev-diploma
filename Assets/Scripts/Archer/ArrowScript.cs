using Assets.Scripts;
using Assets.Scripts.Abstraction;
using System.Collections;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Player Owner { get; set; }
    public int Damage { get; set; }
    public string TargetTag { get; set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _length;

    private Vector2 _originPosition;

    private void Start()
    {
        _originPosition = transform.position;
    }

    private void Update()
    {
        if (IsNeedDestroy())
        {
            DestroyObject();
        }

        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetTag))
        {
            IAggressiveEntity aggressiveEntity = collision.GetComponent<IAggressiveEntity>();
            if(aggressiveEntity is not null)
            {
                aggressiveEntity.DamageWithAggression(Owner, Damage);
            }
            else
            {
                IEntity entity = collision.GetComponent<IEntity>();
                if (entity is not null)
                {
                    entity.Damage(Damage);
                }
            }

            DestroyObject();
        }
    }

    private bool IsNeedDestroy()
    {
        return ((Vector2) transform.position - _originPosition).magnitude >= _length;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
