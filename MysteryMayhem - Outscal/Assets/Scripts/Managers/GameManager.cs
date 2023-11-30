using UnityEditor.Search.Providers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    PLAY,
    CONVERSATION,
    DEDUCTION,
    NULL
}

namespace MysteryMayhem.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private Button playButton;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private GameState gameState = GameState.NULL;
        #endregion --------------------

        #region ---------- Public Variables ----------
        public static GameManager Instace = null;
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            if(Instace == null)
            {
                Instace = this;
            }
            else if(Instace != this)
            {
                Destroy(this);
            }
            DontDestroyOnLoad(gameObject);
            playButton.onClick.AddListener(PlayButton);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void PlayButton()
        {
            SceneManager.LoadScene(1);
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void SetGameState(GameState gameState)
        {
            this.gameState = gameState;
        }

        public GameState GetGameState()
        {
            return gameState;
        }

        public void MenuButton()
        {
            SceneManager.LoadScene(0);
        }
        #endregion --------------------

    }
}
