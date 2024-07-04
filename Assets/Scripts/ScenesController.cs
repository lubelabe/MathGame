using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
