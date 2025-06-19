using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    public PlayerAttack playerAttack;
    private PlayerMovement _playerMovement;
    private float _offsetH = 0.5f;
    private float _offsetV = 1f;
    private Transform _transform;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbodyPlayer;

    private Vector2 _input;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbodyPlayer = GetComponentInParent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void Update()
    {
        _input = _playerMovement.GetInput();
        UpdateHitboxPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Apply damage to enemies
        if (collision.CompareTag("Enemies"))
        {
            playerAttack.Attack(collision.gameObject);
        }
    }

    public void UpdateHitboxPosition()
    {
        if (_input.x > Mathf.Abs(_input.y))
        {
            _sprite.sortingOrder = -1;
            _transform.localPosition = new Vector3(_offsetH, -0.16f, 0);
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_input.x < -Mathf.Abs(_input.y))
        {
            _sprite.sortingOrder = -1;
            _transform.localPosition = new Vector3(-_offsetH, -0.16f, 0);
            _transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (_input.y > Mathf.Abs(_input.x))
        {
            _sprite.sortingOrder = -1;
            _transform.localPosition = new Vector3(0, _offsetV, 0);
            _transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            _sprite.sortingOrder = 1;
            _transform.localPosition = new Vector3(0, -_offsetV, 0);
            _transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}