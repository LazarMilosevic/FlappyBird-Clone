using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _moveSpeed = 1f; //Factor how fast the ground is moving


    private SpriteRenderer _spriteRenderer;

    private Vector2 _sizeOriginal;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _sizeOriginal = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);

        _maxWidth = _sizeOriginal.x * 2;
    }

    private void Update()
    {
        _spriteRenderer.size += Vector2.right * _moveSpeed * Time.deltaTime;

        if (_spriteRenderer.size.x > _maxWidth)
        {
            _spriteRenderer.size = _sizeOriginal;
        }
    }
}
