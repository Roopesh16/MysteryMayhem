using UnityEngine;

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
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
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
        #endregion --------------------

    }
}
