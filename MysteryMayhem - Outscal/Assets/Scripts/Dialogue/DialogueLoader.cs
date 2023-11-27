using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MysteryMayhem.Dialogue
{
    public class DialogueLoader : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        public static DialogueLoader Instance = null;
        #endregion --------------------

        #region ---------- Private Variables ----------
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
            DontDestroyOnLoad(gameObject);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        #endregion --------------------

        #region ---------- Public Methods ----------
        public Queue<string> GetDetBeginQueue()
        {
            string detString = JsonLoader.LoadJson("DetectiveBegin");
            Queue<string> detectiveQueue = JsonConvert.DeserializeObject<Queue<string>>(detString);
            return detectiveQueue;
        }

        public Queue<string> GetDetDialogueQue(Members member)
        {
            return null;
        }

        public Queue<string> GetMemberDialogueQue(Members member)
        {
            return null;
        }
        #endregion --------------------

    }
}

