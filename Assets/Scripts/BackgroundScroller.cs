using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _border;

    void Update()
    {
        if(transform.position.x >= _border)
        {
            Vector3 pos = transform.position;
            pos.x -= 30f;
            transform.position = pos;
        }

        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.World);
    }
}
