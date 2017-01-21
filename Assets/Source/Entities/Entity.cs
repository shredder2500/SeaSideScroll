using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    private float _hitFromTopAngleTolerance = .1f;
    [SerializeField]
    private LayerMask _hitLayerMask;

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
}
