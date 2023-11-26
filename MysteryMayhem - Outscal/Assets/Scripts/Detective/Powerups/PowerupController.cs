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
        #endregion --------------------

        #region ---------- Private Variables ----------
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            lieDetector.SetActive(false);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void TrueButton()
        {
            print("true");
        }

        private void FalseButton()
        {
            print("false");
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void EnableLieDetector()
        {
            lieDetector.SetActive(true);
        }
        #endregion --------------------
    }
}
