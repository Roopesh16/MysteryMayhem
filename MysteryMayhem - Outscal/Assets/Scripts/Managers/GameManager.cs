using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            if (Instace == null)
            {
                Instace = this;
            }
            else if (Instace != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);
            playButton.onClick.AddListener(PlayButton);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void PlayButton()
        {
            GameManager.Instace.SetGameState(GameState.PLAY);
            AudioManager.Instance.PlaySFX(Audio_SFX.BUTTON_CLICK);
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
            AudioManager.Instance.PlaySFX(Audio_SFX.BUTTON_CLICK);
            SceneManager.LoadScene(0);
        }
        #endregion --------------------

    }
}
