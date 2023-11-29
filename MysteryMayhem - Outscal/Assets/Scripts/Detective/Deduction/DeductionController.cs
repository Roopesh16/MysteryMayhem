using MysteryMayhem.Events;
using UnityEngine;
using UnityEngine.UI;

namespace MysteryMayhem.Detective.Deduction
{
    public class DeductionController : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private Button deductionButton;
        [SerializeField] private DeductionView deductionView;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private const int totalDeductions = 7;
        private int deductionsMade = 0;
        private int deductionMissed = 0;
        private bool blonteDecision = false;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            deductionButton.gameObject.SetActive(false);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        #endregion --------------------

        #region ---------- Public Methods ---------
        public void IncrementDeductions(bool hasDeductionMade)
        {
            if (hasDeductionMade)
            {
                deductionsMade++;
            }
            else
            {
                deductionsMade++;
                deductionMissed++;
            }

            if (deductionsMade == totalDeductions)
            {

                deductionButton.gameObject.SetActive(true);
            }
        }

        public void SetBlonteDecision(bool decision)
        {
            blonteDecision = decision;
        }

        public void DeductionButton()
        {
            EventService.Instance.OnFinalDeduction.InvokeEvent();
            //deductionView.DisplayFinalInfo();
        }
        #endregion --------------------
    }
}
