using UnityEngine;

namespace MysteryMayhem.Detective.Deduction
{
    public class DeductionController : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        #endregion --------------------

        #region ---------- Private Variables ----------
        private const int totalDeductions = 7;
        private int currentDeduction = 0;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        #endregion --------------------

        #region ---------- Private Methods ----------
        #endregion --------------------

        #region ---------- Public Methods ---------
        public void IncrementDeductions()
        {
            currentDeduction++;
            if(currentDeduction == totalDeductions)
            {
                // deductionView.DisplayInfo();
            }
        }

        public void BlonteDecision(bool decision)
        {

        }
        #endregion --------------------
    }
}
