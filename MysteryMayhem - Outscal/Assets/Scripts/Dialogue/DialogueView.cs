using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace MysteryMayhem.Dialogue
{
    public class DialogueView : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private Button talkToBtn;
        [SerializeField] private TextMeshProUGUI talkToText;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private Members memberName;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            talkToBtn.gameObject.SetActive(false);
            talkToBtn.onClick.AddListener(TalkToBtn);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void TalkToBtn()
        {
            talkToBtn.gameObject.SetActive(false);
        }

        private void SetBtnText()
        {
            talkToBtn.gameObject.SetActive(true);
            talkToText.text = "Talk to " + memberName;
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void LoadDialogues(Members memberName)
        {
            this.memberName = memberName;
            SetBtnText();
        }

        public void DisableDialogueBtn()
        {
            talkToBtn.gameObject.SetActive(false);
        }
        #endregion --------------------
    }
}
