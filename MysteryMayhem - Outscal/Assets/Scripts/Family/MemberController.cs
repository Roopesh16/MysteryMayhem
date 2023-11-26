using MysteryMayhem.Detective;
using MysteryMayhem.Dialogue;
using UnityEngine;

public enum Members
{
    JACK,
    ANNA,
    KENNETH,
    BLONTE
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
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Update()
        {
            if (Vector2.Distance(detective.transform.position, transform.position) <= minDistance)
            {
                detective.GetComponent<DetectiveController>().DisplayLieDetector();
                dialogueView.LoadDialogues(memberName);
            }
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        #endregion --------------------

        #region ---------- Public Methods ----------
        #endregion --------------------
    }
}

