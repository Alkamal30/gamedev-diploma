using Assets.Scripts.Abstraction;
using System.Collections;
using UnityEngine;

public class DynamiteScript : MonoBehaviour
{
    [SerializeField] private float _explosionDuration;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _shadow;
    public Vector2 TargetPosition { get; set; }
    public float Duration { get; set; }


    private Vector2 _startPosition;
    private float _startTime;
    private bool _isMove;

    private void Start()
    {
        _startPosition = transform.position;
        _startTime = Time.time;
        _isMove = true;
    }

    public void Update()
    {
        if(!_isMove)
        {
            return;
        }

        float time = Mathf.Clamp(Time.time - _startTime, 0f, Duration) / Duration;
        transform.position = Vector2.Lerp(_startPosition, TargetPosition, time);

        _shadow.transform.position = TargetPosition;
        _shadow.transform.eulerAngles = Vector3.zero;
        _shadow.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one / 2f, time);

        if (time == 1f)
        {
            _isMove = false;
            _animator.SetTrigger("Explode");
            StartCoroutine(DestroyObject());
        }
    }

    private IEnumerator DestroyObject()
    {
        DamageEntities();

        yield return new WaitForSeconds(_explosionDuration);

        Destroy(gameObject);
    }

    private void DamageEntities()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.9f);

        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                IEntity entity = collider.GetComponent<IEntity>();

                if(entity != null)
                {
                    entity.Damage(1);
                }
            }
        }
    }
}
