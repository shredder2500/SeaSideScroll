using System.Collections;
using System.Collections.Generic;
using SeaSideScroll.Entities.Movement;
using UnityEngine;
using UniRx;
using Zenject;
using SeaSideScroll.Input;

namespace SeaSideScroll.Entities.Movement
{
	public class MovementAnimationController : MonoBehaviour
	{
		private Animator _animator;
		private Rigidbody2D _rigidbody;

		[Inject]
		private IInput _input;

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
            if (_input == null) return;
			Vector2 velocity = _input.MovementInput.Value;
			Debug.Log (velocity);

			if (velocity.x > 0) 
			{
				_animator.SetBool ("isWalking", true);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (velocity.x < 0)
			{
				_animator.SetBool ("isWalking", true);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
			 else if (velocity.x == 0)
				_animator.SetBool ("isWalking", false);

			_animator.SetFloat ("UpVelocity", velocity.y);

				
		}
	}
}
