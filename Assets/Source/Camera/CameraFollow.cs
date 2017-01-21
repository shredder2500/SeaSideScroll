using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seaside.Camera
{
	public class CameraFollow : MonoBehaviour 
	{
		public Transform _player;

		[SerializeField]
		private float _playerDist = 10;
		[SerializeField]
		private float _ySensitivity = 1f;
		[SerializeField]
		private float _xSensitivity = 1f;

		// Use this for initialization
		void Start () 
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			float newPositionX = Mathf.Lerp (transform.position.x, _player.position.x, Time.deltaTime * _xSensitivity);
			float newPositionY = Mathf.Lerp (transform.position.y, _player.position.y, Time.deltaTime * _ySensitivity);
			transform.position = new Vector3 (newPositionX, newPositionY, -_playerDist);
		}
	}
}
