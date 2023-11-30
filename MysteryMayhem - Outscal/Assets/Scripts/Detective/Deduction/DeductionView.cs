using System.Collections;
using System.Collections.Generic;
using MysteryMayhem.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MysteryMayhem.Detective.Deduction
{
    public class DeductionView : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [Header("Deduction Info")]
        [SerializeField] private GameObject deductionInfoBox;
        [SerializeField] private TextMeshProUGUI missedDeductionText;
        [SerializeField] private GameObject successMsgObject;
        [SerializeField] private GameObject failMsgObject;
        [SerializeField] private Button menuButton;
        #endregion --------------------

        #region ---------- Private Variables ----------
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            deductionInfoBox.SetActive(false);
            successMsgObject.SetActive(false);
            failMsgObject.SetActive(false);
            menuButton.onClick.AddListener(MenuButton);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void MenuButton()
        {
            GameManager.Instace.MenuButton();
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void EnableDeductionInfo()
        {
            deductionInfoBox.SetActive(true);
        }

        public void SetDeductionData(int missDeduction, bool blonteDecision)
        {
            missedDeductionText.text = missDeduction.ToString();

            if(blonteDecision)
            {
                successMsgObject.SetActive(true);
                failMsgObject.SetActive(false);
            }
            else
            {
                failMsgObject.SetActive(true);
                successMsgObject.SetActive(false);
            }
        }
        #endregion --------------------
    }
}

