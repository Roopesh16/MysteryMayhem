using System.Collections;
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
        #endregion --------------------

        #region ---------- Private Variables ----------
        private const float maxTimer = 10f;
        private bool isDetectorEnable = false;
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
            timerImage.fillAmount = 1;
            StopCoroutine(EnableLieDetector());
            lieDetector.SetActive(false);
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public IEnumerator EnableLieDetector()
        {
            isDetectorEnable = true;
            lieDetector.SetActive(true);
            float time = 0f;
            float maxFill = 1f;
            float zeroFill = 0f;
            while (time < maxTimer)
            {
                timerImage.fillAmount = Mathf.Lerp(maxFill, zeroFill, time / maxTimer);
                time += Time.deltaTime;
                yield return null;
            }
            timerImage.fillAmount = zeroFill;
            lieDetector.SetActive(false);
            timerImage.fillAmount = maxFill;
        }
        #endregion --------------------
    }
}
