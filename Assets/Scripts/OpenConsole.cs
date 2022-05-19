using UnityEngine;

public class OpenConsole : MonoBehaviour
{
    [SerializeField] private GameObject _console;
    
    public void ShowOrHideConsole()
    {
        if (!_console.activeInHierarchy)
        {
            _console.SetActive(true);
        }
        if (!_console.activeInHierarchy)
        {
            _console.SetActive(false);
        }
    }
}
