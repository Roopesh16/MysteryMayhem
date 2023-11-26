using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MysteryMayhem.Dialogue
{
    public class DialogueView : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [Header("Talk to")]
        [SerializeField] private Button talkToBtn;
        [SerializeField] private TextMeshProUGUI talkToText;

        [Header("Dialogues")]
        [SerializeField] private Image speakerImage;
        [SerializeField] private TextMeshProUGUI speakerName;
        [SerializeField] private TextMeshProUGUI speakerText;

        [Header("References")]
        [SerializeField] private string detectiveName;
        [SerializeField] private SpriteRenderer detectiveSprite;
        [SerializeField] private List<SpriteRenderer> memberSprites;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private Members member;
        private string memberName;
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
            member = memberName;
            SetBtnText();
        }

        public void DisableDialogueBtn()
        {
            talkToBtn.gameObject.SetActive(false);
        }
        #endregion --------------------
    }
}
