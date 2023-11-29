using UnityEngine;

namespace MysteryMayhem.Detective.Deduction
{
    public class DeductionController : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        #endregion --------------------

        #region ---------- Private Variables ----------
        private const int totalDeductions = 7;
        private int deductionsMade = 0;
        private int deductionMissed = 0;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
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
                // deductionView.DisplayInfo(int deductionsMade, int deductionMissed);
            }
        }

        public void BlonteDecision(bool decision)
        {

        }
        #endregion --------------------
    }
}
