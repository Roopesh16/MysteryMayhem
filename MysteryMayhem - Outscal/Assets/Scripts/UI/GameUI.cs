using UnityEngine;
using UnityEngine.UI;

namespace MysteryMayhem.UI
{
    public class GameUI : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private Button pauseBtn;
        [SerializeField] private Button resumeBtn;
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            pauseBtn.onClick.AddListener(PauseButton);
            resumeBtn.onClick.AddListener(ResumeButton);
            pauseBtn.gameObject.SetActive(true);
            resumeBtn.gameObject.SetActive(false);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void PauseButton()
        {
            pauseBtn.gameObject.SetActive(false);
            resumeBtn.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void ResumeButton()
        {
            Time.timeScale = 1;
            pauseBtn.gameObject.SetActive(true);
            resumeBtn.gameObject.SetActive(false);
        }
        #endregion --------------------

    }
}
