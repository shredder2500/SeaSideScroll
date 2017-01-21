using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace SeaSideScroll.Entities
{
	public class MovementAnimationController : MonoBehaviour
	{
		private Animator _animator;
		private Rigidbody2D _rigidbody;

		// Use this for initialization
		void Start () 
		{
			_animator = GetComponent <Animator> ();
			_rigidbody = GetComponent <Rigidbody2D> ();
		}
	
		// Update is called once per frame
		void Update () 
		{
			SetAnimationParameters ();
		}

		void SetAnimationParameters ()
		{
			Vector2 velocity = _rigidbody.velocity;

			Debug.Log (velocity);
			/*
			if (velocity.x < 0) {
				_animator.SetBool ("isWalking", true);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (velocity.x > 0)
			{
				_animator.SetBool ("isWalking", true);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
			 else if (velocity.x == 0)
				_animator.SetBool ("isWalking", false);

			*/

			_animator.SetFloat ("UpVelocity", velocity.y);
				
		}
	}
}
