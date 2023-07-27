using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _instructionsButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _confirmQuitButton;
    [SerializeField] private Button _closeQuitButton;
    [SerializeField] private Button _closeInstructionsButton;
    
    [SerializeField] private GameObject _instructionsPanel;
    [SerializeField] private GameObject _quitPanel;

    private void Awake()
    {
        _playButton.onClick.AddListener(StartGame);   
        _quitButton.onClick.AddListener(ShowQuitGame);   
        _instructionsButton.onClick.AddListener(ShowInstructions);   
        _confirmQuitButton.onClick.AddListener(QuitGame);
        _closeQuitButton.onClick.AddListener(CloseQuitGame);   
        _closeInstructionsButton.onClick.AddListener(CloseInstructions);   
        
        _instructionsPanel.SetActive(false);
        _quitPanel.SetActive(false);
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
    }
    
    private void ShowQuitGame()
    {
        _quitPanel.SetActive(true);
    }
    
    private void ShowInstructions()
    {
        _instructionsPanel.SetActive(true);
    }
    
    private void CloseInstructions()
    {
        _instructionsPanel.SetActive(false);
    }

    private void CloseQuitGame()
    {
        _quitPanel.SetActive(false);
    }
    
    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(StartGame);   
        _quitButton.onClick.RemoveListener(ShowQuitGame);   
        _instructionsButton.onClick.RemoveListener(ShowInstructions);   
        _confirmQuitButton.onClick.RemoveListener(QuitGame);
        _closeQuitButton.onClick.RemoveListener(CloseQuitGame);   
        _closeInstructionsButton.onClick.RemoveListener(CloseInstructions);  
    }
}
