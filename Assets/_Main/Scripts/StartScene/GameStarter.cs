using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.StartScene
{
    public class GameStarter : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
