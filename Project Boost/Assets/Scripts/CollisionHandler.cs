using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _delay = 1.5f;
    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("You hit a friendly");
                break;
            case "Finish":
                Debug.Log("You won!");
                StartWinSequence();
                break;
            default:
                Debug.Log("You died");
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", _delay);
    }

    private void StartWinSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", _delay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}
