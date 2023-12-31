using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MysteryMayhem.Manager;
using System.Collections.Generic;

namespace MysteryMayhem.Objects
{
    public class ObjectInfoView : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [Header("History Info")]
        [SerializeField] private GameObject historyInfoBox;
        [SerializeField] private TextMeshProUGUI historyInfoText;
        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI[] namesText = new TextMeshProUGUI[3];
        [SerializeField] private ObjectInfo[] objects = new ObjectInfo[3];
        #endregion --------------------

        #region ---------- Private Variables ----------
        private ObjectType objectType = ObjectType.NULL;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            historyInfoBox.SetActive(false);
            DisableNameText();
            closeButton.onClick.AddListener(CloseHistoryBox);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------

        private void SetHistoryInfo()
        {
            historyInfoText.text = objects[(int)objectType].GetHistoryInfo();
            List<string> namesString = objects[(int)objectType].GetHistoryList();
            for (int i = 0; i < namesString.Count; i++)
            {
                namesText[i].gameObject.SetActive(true);
                namesText[i].text = namesString[i];
            }
        }

        private void DisableNameText()
        {
            for (int i = 0; i < namesText.Length; i++)
            {
                namesText[i].text = "";
                namesText[i].gameObject.SetActive(false);
            }
        }

        private void CloseHistoryBox()
        {
            GameManager.Instace.SetGameState(GameState.PLAY);
            AudioManager.Instance.PlaySFX(Audio_SFX.BUTTON_CLICK);
            objectType = ObjectType.NULL;
            historyInfoBox.SetActive(false);
            historyInfoText.text = "";
            DisableNameText();
        }

        #endregion --------------------

        #region ---------- Public Methods ----------
        public void DisplayHistoryBox()
        {
            historyInfoBox.SetActive(true);
            SetHistoryInfo();
        }

        public void SetObjectType(ObjectType objectType)
        {
            this.objectType = objectType;
        }
        #endregion --------------------
    }
}
