using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MysteryMayhem.Events;

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
        [SerializeField] private Button nextButton;

        [Header("References")]
        [SerializeField] private string detectiveName;
        [SerializeField] private Sprite detectiveSprite;
        [SerializeField] private List<Sprite> memberSprites;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private Members memberType;
        private string memberName;
        private Sprite memberSprite;
        private bool isDetSpeak = true;
        private Queue<string> detectiveQueue = new Queue<string>();
        private Queue<string> memberQueue = new Queue<string>();
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            talkToBtn.gameObject.SetActive(false);
            dialogueBox.SetActive(false);
            nextButton.onClick.AddListener(DequeueDialogues);
            talkToBtn.onClick.AddListener(TalkToBtn);
        }

        private void Start()
        {
            LoadDetectiveBegin();
        }

        #endregion --------------------

        #region ---------- Private Methods ----------
        private void InitialDetDialogue()
        {
            dialogueBox.SetActive(true);
            speakerImage.sprite = detectiveSprite;
            speakerName.text = detectiveName;
            speakerDialogue.text = detectiveQueue.Dequeue();
        }
        private void LoadDetectiveBegin()
        {
            detectiveQueue = DialogueLoader.Instance.GetDetBeginQueue();
            InitialDetDialogue();
        }

        private void DequeueDialogues()
        {
            if (detectiveQueue.Count == 0 && memberQueue.Count == 0)
            {
                DisableDialogueBox();
                return;
            }

            if (isDetSpeak && detectiveQueue.Count > 0)
            {
                speakerImage.sprite = detectiveSprite;
                speakerName.text = detectiveName;
                speakerDialogue.text = detectiveQueue.Dequeue();
            }
            else if (!isDetSpeak && memberQueue.Count > 0)
            {
                speakerImage.sprite = memberSprite;
                speakerName.text = memberName;
                speakerDialogue.text = memberQueue.Dequeue();
            }

            if (detectiveQueue.Count == 0)
            {
                isDetSpeak = false;
            }
            else if (memberQueue.Count == 0)
            {
                isDetSpeak = true;
            }
            else
            {
                isDetSpeak = !isDetSpeak;
            }
        }

        private void TalkToBtn()
        {
            talkToBtn.gameObject.SetActive(false);
            dialogueBox.SetActive(true);
            StartMemberDialogue();
        }

        private void SetBtnText()
        {
            talkToBtn.gameObject.SetActive(true);
            talkToText.text = "Talk to " + memberName;
        }

        private void StartMemberDialogue()
        {
            detectiveQueue = DialogueLoader.Instance.GetDetDialogueQue(memberType);
            memberQueue = DialogueLoader.Instance.GetMemberDialogueQue(memberType);
            InitialDetDialogue();
        }

        private void DisableDialogueBox()
        {
            dialogueBox.SetActive(false);
            detectiveQueue.Clear();
            memberQueue.Clear();
            EventService.Instance.OnConversationEnd.InvokeEvent();
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
                    memberName = "Maid Anna";
                    break;
                case Members.KENNETH:
                    memberName = "Mr. Kenneth";
                    break;
                case Members.BLONTE:
                    memberName = "Ms. Blonte";
                    break;
            }
            memberSprite = memberSprites[(int)member];
            memberType = member;
            SetBtnText();
        }

        public void DisableDialogueBtn()
        {
            talkToBtn.gameObject.SetActive(false);
        }
        #endregion --------------------
    }
}
