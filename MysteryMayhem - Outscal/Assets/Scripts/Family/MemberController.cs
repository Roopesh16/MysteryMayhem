using UnityEngine;
using MysteryMayhem.Dialogue;

public enum Members
{
    JACK,
    ANNA,
    KENNETH,
    BLONTE,
    NULL
}
namespace MysteryMayhem.Family
{
    public class MemberController : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private Members memberName;
        [SerializeField] private Transform detective;
        [SerializeField] private DialogueView dialogueView;
        [SerializeField] private float minDistance = 2f;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private bool canLoadDialogue = false;
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Update()
        {
            if ((Vector2.Distance(detective.transform.position, transform.position) <= minDistance) && !canLoadDialogue)
            {
                canLoadDialogue = true;
                dialogueView.SetMember(memberName);
            }

            if ((Vector2.Distance(detective.transform.position, transform.position) > minDistance) && canLoadDialogue)
            {
                canLoadDialogue = false;
                dialogueView.ResetMember();
                dialogueView.DisableTalkToBtn();
            }
        }
        #endregion --------------------
    }
}

