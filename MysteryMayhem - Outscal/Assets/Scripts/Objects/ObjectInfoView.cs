using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        #endregion --------------------

        #region ---------- Private Variables ----------
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            historyInfoBox.SetActive(false);
            closeButton.onClick.AddListener(CloseHistoryBox);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void DisplayHistoryBox(ObjectType objectType)
        {
            historyInfoBox.SetActive(true);
        }

        private void CloseHistoryBox()
        {
            historyInfoBox.SetActive(false);
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        #endregion --------------------
    }
}
