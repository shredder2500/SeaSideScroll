using SeaSideScroll.Entities.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(PlatformMovement))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    private float _hitFromTopAngleTolerance = .1f;
    [SerializeField]
    private LayerMask _hitLayerMask;
    [SerializeField]
    private float _groundCheckDis = .3f;
    [SerializeField]
    private LayerMask _groundLayerMask;

    private Vector2 _moveDir = Vector2.left;
    private IMovementController _movementController;

    private void Start()
    {
        _movementController = GetComponent<IMovementController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hitLayerMask == (_hitLayerMask | (1 << collision.gameObject.layer)))
        {
            if (Vector2.Dot(-collision.relativeVelocity.normalized, Vector2.down) > (1 - _hitFromTopAngleTolerance))
            {
                OnHitFromTop(collision);
            }
            else
            {
                OnHit(collision);
            }
        }
    }

    protected abstract void OnHit(Collision2D collision);

    protected abstract void OnHitFromTop(Collision2D collision);

    protected virtual void Update()
    {
        Move();

        if(Physics2D.Raycast(transform.position, _moveDir, _groundCheckDis, _groundLayerMask))
        {
            _moveDir = -_moveDir;
        }
    }

    protected void Move()
    {
        _movementController.Move(_moveDir);
        transform.localScale = new Vector3(-_moveDir.x, 1, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, _moveDir * _groundCheckDis);
    }
}
