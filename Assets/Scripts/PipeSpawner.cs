using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 3f;
    [SerializeField] private float _heigthRange = 0.65f;
    [SerializeField] private GameObject _pipeOriginal;

    private float _timer;

    void Start()
    {
        spawnPipe();
    }

    private void Update()
    {
        if (_timer >= _maxTime)
        {
            spawnPipe();
            _timer = 0f;
        }
        _timer += Time.deltaTime;
    }

    private void spawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3 (0f, Random.Range(-_heigthRange, _heigthRange), 0f);
        GameObject _pipeClone = Instantiate(_pipeOriginal, spawnPos, Quaternion.identity);

        Destroy(_pipeClone, 6.7f);
    }
}
