using System;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteRainScript : MonoBehaviour
{
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private float _cellSize;
    [SerializeField] private GameObject _dynamitePrefab;

    private List<Action> _spawners;
    private int _currentSpawner;

    public void SpawnNextWave()
    {
        _spawners[_currentSpawner++].Invoke();
        _currentSpawner %= _spawners.Count;
    }

    private void Awake()
    {
        _spawners = new List<Action>
        {
            SpawnVerticalWave,
            SpawnHorizontalWave,
            SpawnDiagonalWave,
        };

        _currentSpawner = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                Vector2 position = CalculatePosition(i, j);
                Gizmos.DrawWireCube(position, new Vector3(_cellSize, _cellSize));
            }
        }
    }

    private void SpawnVerticalWave()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j += 2)
            {
                SpawnDynamite(i, j);
            }
        }
    }

    private void SpawnHorizontalWave()
    {
        for (int i = 0; i < _rows; i += 2)
        {
            for (int j = 0; j < _columns; j++)
            {
                SpawnDynamite(i, j);
            }
        }
    }

    private void SpawnDiagonalWave()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                if((i + j) % 2 == 0)
                {
                    SpawnDynamite(i, j);
                }
            }
        }
    }

    private void SpawnDynamite(int row, int column)
    {
        Vector2 position = CalculatePosition(row, column);
        Vector2 originPosition = position + Vector2.up * 2f;

        GameObject dynamite = Instantiate(_dynamitePrefab);
        dynamite.transform.position = originPosition;

        DynamiteScript dynamiteScript = dynamite.GetComponent<DynamiteScript>();
        dynamiteScript.Duration = 1f;
        dynamiteScript.TargetPosition = position;
    }

    private Vector2 CalculatePosition(int row, int column)
    {
        float width = _rows * _cellSize;
        float height = _columns * _cellSize;

        return new Vector2(
            row * _cellSize + transform.position.x + _cellSize / 2 - width / 2,
            column * _cellSize + transform.position.y + _cellSize / 2 - height / 2
        );
    }
}
