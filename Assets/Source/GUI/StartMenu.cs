using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SeasideScroll.GUI
{
	public class StartMenu : MonoBehaviour 
	{
		[SerializeField]
		private string _startScene;

		public void StartGame ()
		{
			SceneManager.LoadScene (_startScene);
		}
	}
}
