using System;
using UnityEngine;

public class GroundLoopV2 : MonoBehaviour
{
    [SerializeField] private GameObject _groundA;
    [SerializeField] private GameObject _groundB;

    [SerializeField] private float _speed = 0.5f; //ideal same as pillar speed

    private Vector3 _resetPos;
    private float _width = 3.36f;

    private void Start()
    {
        _resetPos = _groundA.transform.position - new Vector3(3.36f, 0f, 0f);
    }

    void Update()
    {
        MoveGround(_groundA);
        MoveGround(_groundB);

        if (_groundA.transform.position.x <= _resetPos.x)
        {
            _groundA.transform.position = _groundB.transform.position +Vector3.right * _width;
        }
        if (_groundB.transform.position.x <= _resetPos.x)
        {
            _groundB.transform.position = _groundA.transform.position + Vector3.right * _width;
        }

    }


    private void MoveGround(GameObject obj)
    {
        obj.transform.position += Vector3.left * _speed * Time.deltaTime;
    }

}
