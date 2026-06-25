using UnityEngine;

public class movePillar : MonoBehaviour
{

    [SerializeField] private float _speed = 0.5f;

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
