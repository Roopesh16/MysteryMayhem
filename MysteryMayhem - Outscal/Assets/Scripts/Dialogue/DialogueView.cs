using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace MysteryMayhem.Dialogue
{
    public class DialogueView : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [Header("Talk to")]
        [SerializeField] private Button talkToBtn;
        [SerializeField] private TextMeshProUGUI talkToText;

        [Header("Dialogues")]
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private Image speakerImage;
        [SerializeField] private TextMeshProUGUI speakerName;
        [SerializeField] private TextMeshProUGUI speakerDialogue;

        [Header("References")]
        [SerializeField] private string detectiveName;
        [SerializeField] private Sprite detectiveSprite;
        [SerializeField] private List<Sprite> memberSprites;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private string memberName;
        private Sprite memberSprite;
        private Queue<string> beginQueue = new Queue<string>();
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            talkToBtn.gameObject.SetActive(false);
            dialogueBox.SetActive(false);
            talkToBtn.onClick.AddListener(TalkToBtn);
        }

        private void Start()
        {
            LoadDetectiveBegin();
        }

        #endregion --------------------

        #region ---------- Private Methods ----------
        private void LoadDetectiveBegin()
        {
            dialogueBox.SetActive(true);
            speakerImage.sprite = detectiveSprite;
            speakerName.text = detectiveName;

            beginQueue = DialogueLoader.Instance.GetDetectiveBegin();
            speakerDialogue.text = beginQueue.Dequeue();
        }

        private void TalkToBtn()
        {
            talkToBtn.gameObject.SetActive(false);
            EnableDialogueBox();
        }

        private void SetBtnText()
        {
            talkToBtn.gameObject.SetActive(true);
            talkToText.text = "Talk to " + memberName;
        }

        private void EnableDialogueBox()
        {
            dialogueBox.SetActive(true);
            speakerImage.sprite = detectiveSprite;
            speakerName.text = detectiveName;
            speakerDialogue.text = "Hello, my name is Detective Ida.";
        }

        private void StartBlonteDialogue()
        {

        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void SetMember(Members member)
        {
            switch (member)
            {
                case Members.JACK:
                    memberName = "Jack";
                    break;
                case Members.ANNA:
                    memberName = "Anna";
                    break;
                case Members.KENNETH:
                    memberName = "Kenneth";
                    break;
                case Members.BLONTE:
                    memberName = "Blonte";
                    StartBlonteDialogue();
                    break;
            }
            memberSprite = memberSprites[(int)member];
            SetBtnText();
        }

        public void DisableDialogueBtn()
        {
            talkToBtn.gameObject.SetActive(false);
        }
        #endregion --------------------
    }
}
