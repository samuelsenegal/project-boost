using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        int _currentScene = SceneManager.sceneCount;
        switch(collision.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("You hit a friendly");
                break;
            case "Finish":
                Debug.Log("You won!");
                break;
            default:
                Debug.Log("You died");
                ReloadLevel(_currentScene);
                break;
        }
    }

    private void ReloadLevel(int _currentScene)
    {
        SceneManager.LoadScene(_currentScene);
    }
}
