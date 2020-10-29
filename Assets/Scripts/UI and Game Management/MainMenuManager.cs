using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private static MainMenuManager _instance;
    [HideInInspector] public static MainMenuManager Instance { get { return _instance; } }

    void Awake()
	{
		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        } 
    }

    private void Start()
    {
        // play theme song
        // Add song to audio manager with matching name and uncomment to play.
        // AudioManager.instance.Play("theme_song");
    }

    void Update()
    {
        if (Input.GetKeyUp("escape")) // quit to main menu if pressing escape			
			QuitGame();
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
