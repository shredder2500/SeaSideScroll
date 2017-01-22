using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SeasideScroll.GUI
{
	public class StartMenu : MonoBehaviour 
	{
        public const string USE_TOBII_KEY = "USE_TOBII";

		[SerializeField]
		private string _startScene;

		public void StartGame (bool useTobii)
		{
            PlayerPrefs.SetInt(USE_TOBII_KEY, useTobii ? 1 : 0);
			SceneManager.LoadScene (_startScene);
		}
	}
}
