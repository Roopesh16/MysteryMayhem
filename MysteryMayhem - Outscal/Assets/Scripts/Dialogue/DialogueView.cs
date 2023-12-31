using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MysteryMayhem.Events;
using MysteryMayhem.Manager;
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
        [SerializeField] private Button nextButton;

        [Header("Detective References")]
        [SerializeField] private string detectiveName;
        [SerializeField] private Sprite detectiveSprite;
        [SerializeField] private List<Sprite> memberSprites;

        [Header("References")]
        [SerializeField] private DialogueLoader dialogueLoader;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private Members memberType = Members.NULL;
        private string memberName;
        private Sprite memberSprite;
        private bool isDetSpeak = true;
        private bool[] hasMemberSpoken = new bool[4];
        private Queue<string> detectiveQueue = new Queue<string>();
        private Queue<string> memberQueue = new Queue<string>();
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            talkToBtn.gameObject.SetActive(false);
            nextButton.onClick.AddListener(DequeueDialogues);
            talkToBtn.onClick.AddListener(TalkToBtn);
        }

        private void OnEnable()
        {
            EventService.Instance.OnFinalDeduction.AddListener(DisableTalkToBtn);
        }

        private void OnDisable()
        {
            EventService.Instance.OnFinalDeduction.RemoveListener(DisableTalkToBtn);
        }

        private void Start()
        {
            GameManager.Instace.SetGameState(GameState.CONVERSATION);
            for (int i = 0; i < hasMemberSpoken.Length; i++)
            {
                hasMemberSpoken[i] = false;
            }
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
            detectiveQueue = dialogueLoader.GetDetBeginQueue();
            InitialDetDialogue();
        }

        private void DequeueDialogues()
        {
            AudioManager.Instance.PlaySFX(Audio_SFX.NEXT);
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
            AudioManager.Instance.PlaySFX(Audio_SFX.BUTTON_CLICK);
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
            GameManager.Instace.SetGameState(GameState.CONVERSATION);
            if (hasMemberSpoken[(int)memberType])
            {
                speakerName.text = "";
                speakerImage.enabled = false;
                memberQueue = dialogueLoader.GetMemberSpokenQue();
                speakerDialogue.text = memberQueue.Dequeue();
            }
            else
            {
                speakerImage.enabled = true;
                detectiveQueue = dialogueLoader.GetDetDialogueQue(memberType);
                memberQueue = dialogueLoader.GetMemberDialogueQue(memberType);
                InitialDetDialogue();
            }
        }

        private void DisableDialogueBox()
        {
            dialogueBox.SetActive(false);
            detectiveQueue.Clear();
            memberQueue.Clear();
            if (memberType != Members.NULL && !hasMemberSpoken[(int)memberType])
            {
                hasMemberSpoken[(int)memberType] = true;
                EventService.Instance.OnConversationEnd.InvokeEvent();
            }
            GameManager.Instace.SetGameState(GameState.PLAY);
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

        public void ResetMember()
        {
            memberType = Members.NULL;
        }

        public void DisableTalkToBtn()
        {
            talkToBtn.gameObject.SetActive(false);
        }
        public Members GetMemberType()
        {
            return memberType;
        }
        #endregion --------------------
    }
}
