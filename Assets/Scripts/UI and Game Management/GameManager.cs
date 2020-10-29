using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
    [HideInInspector] public static GameManager Instance { get { return _instance; } }

    void Awake()
	{
		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        } 
    }

    void Update()
    {
        if (Input.GetKeyUp("escape")) // quit to main menu if pressing escape			
			SceneManager.LoadScene(0);
    }
}
