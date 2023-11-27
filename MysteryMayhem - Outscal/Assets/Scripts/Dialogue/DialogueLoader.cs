using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MysteryMayhem.Dialogue
{
    public class DialogueLoader : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        #endregion --------------------

        #region ---------- Private Variables ----------
        private Queue<string> detBeginDialogues = new Queue<string>();
        private Queue<string> jackDialogues = new Queue<string>();
        private Queue<string> annaDialogue = new Queue<string>();
        private Queue<string> kennethDialogue = new Queue<string>();
        private Queue<string> blonteDialogue = new Queue<string>();
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            string detectiveString = JsonLoader.LoadJson("DetectiveBegin");
            detBeginDialogues = JsonConvert.DeserializeObject<Queue<string>>(detectiveString);

        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        #endregion --------------------

        #region ---------- Public Methods ----------
        #endregion --------------------
    }
}

