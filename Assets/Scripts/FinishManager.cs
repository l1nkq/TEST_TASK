using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
