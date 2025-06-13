using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
