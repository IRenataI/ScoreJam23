using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MapBuilding");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
