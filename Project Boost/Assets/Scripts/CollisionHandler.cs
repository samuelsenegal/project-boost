using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip _success;
    [SerializeField] AudioClip _fail;
    [SerializeField] private float _delay = 1.5f;

    AudioSource _audio;

    private bool _isTransitioning = false;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("You hit a friendly");
                break;
            case "Finish":
                if (!_isTransitioning)
                {
                    StartWinSequence();
                }
                break;
            default:
                if (!_isTransitioning)
                {
                    StartCrashSequence();
                }
                break;
        }
    }

    private void StartCrashSequence()
    {
        // TODO: Add Flair
        _isTransitioning = true;
        _audio.Stop();
        _audio.PlayOneShot(_fail);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", _delay);
    }

    private void StartWinSequence()
    {
        // TODO: Add Flair
        _isTransitioning = true;
        _audio.Stop();
        _audio.PlayOneShot(_success);
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
