using System.Collections;
using MysteryMayhem.Detective.Deduction;
using MysteryMayhem.Events;
using MysteryMayhem.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace MysteryMayhem.Detective.Powerup
{
    public class PowerupController : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [Header("Lie Detector")]
        [SerializeField] private GameObject lieDetector;
        [SerializeField] private Button trueBtn;
        [SerializeField] private Button falseBtn;
        [SerializeField] private Image timerImage;

        [Header("References")]
        [SerializeField] private DeductionController deductionController;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private const float maxTimer = 10f;
        private const float zeroFill = 0f;
        private const float maxFill = 1f;
        private float time = 0f;
        private IEnumerator lieCoroutine;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            lieDetector.SetActive(false);
            trueBtn.onClick.AddListener(TrueButton);
            falseBtn.onClick.AddListener(FalseButton);
        }

        private void OnEnable()
        {
            EventService.Instance.OnConversationEnd.AddListener(OnConversationEnd);
        }

        private void OnDisable()
        {
            EventService.Instance.OnConversationEnd.RemoveListener(OnConversationEnd);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void TrueButton()
        {
            DisableLieDetector();
        }

        private void FalseButton()
        {
            DisableLieDetector();
        }

        private void DisableLieDetector()
        {
            GameManager.Instace.SetGameState(GameState.PLAY);
            deductionController.IncrementDeductions();
            lieDetector.SetActive(false);
            time = 0f;
            StopCoroutine(lieCoroutine);
            timerImage.fillAmount = maxFill;
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public IEnumerator EnableLieDetector()
        {
            while (time < maxTimer)
            {
                timerImage.fillAmount = Mathf.Lerp(maxFill, zeroFill, time / maxTimer);
                time += Time.deltaTime;
                yield return null;
            }
            timerImage.fillAmount = zeroFill;
            time = 0f;
            lieDetector.SetActive(false);
            timerImage.fillAmount = maxFill;
        }

        public void OnConversationEnd()
        {
            lieDetector.SetActive(true);
            lieCoroutine = EnableLieDetector();
            StartCoroutine(lieCoroutine);
        }
        #endregion --------------------
    }
}
