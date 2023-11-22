using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Awake()
    {
        Destroy(NetworkManager.GetLocalPlayer()); //Destroy the player when the game is over. 
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
