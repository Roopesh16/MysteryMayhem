using UnityEngine;
using UnityEngine.UI;

namespace MysteryMayhem.Dialogue
{
    public class DialogueView : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private Button talkToBtn;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private Members memberName;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            talkToBtn.onClick.AddListener(TalkToBtn);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void TalkToBtn()
        {
            
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void LoadDialogues(Members memberName)
        {
            this.memberName = memberName;
        }
        #endregion --------------------
    }
}
