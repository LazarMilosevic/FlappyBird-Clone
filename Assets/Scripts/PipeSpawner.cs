using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 3f;
    [SerializeField] private float heigthRange = 0.55f;
    [SerializeField] private GameObject pipeOriginal;

    private float _timer;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (_timer >= maxTime)
        {
            SpawnPipe();
            _timer = 0f;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3 (0f, Random.Range(-heigthRange, heigthRange), 0f);
        GameObject _pipeClone = Instantiate(pipeOriginal, spawnPos, Quaternion.identity);

        Destroy(_pipeClone, 6.7f);
    }
}
