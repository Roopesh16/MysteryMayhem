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

        #region ---------- Public Methods ----------
        public Queue<string> GetDetBeginQueue()
        {
            string detString = JsonLoader.LoadJson("DetectiveBegin");
            Queue<string> detectiveQueue = JsonConvert.DeserializeObject<Queue<string>>(detString);
            return detectiveQueue;
        }

        public Queue<string> GetDetDialogueQue(Members member)
        {
            string detString = null;
            switch (member)
            {
                case Members.JACK:
                    detString = JsonLoader.LoadJson("DetectiveToJack");
                    break;
                case Members.ANNA:
                    detString = JsonLoader.LoadJson("DetectiveToAnna");
                    break;
                case Members.KENNETH:
                    detString = JsonLoader.LoadJson("DetectiveToKenneth");
                    break;
                case Members.BLONTE:
                    detString = JsonLoader.LoadJson("DetectiveToBlonte");
                    break;
            }
            Queue<string> detectiveQueue = JsonConvert.DeserializeObject<Queue<string>>(detString);
            return detectiveQueue;
        }

        public Queue<string> GetMemberDialogueQue(Members member)
        {
            string memString = null;
            switch (member)
            {
                case Members.JACK:
                    memString = JsonLoader.LoadJson("JackToDetective");
                    break;
                case Members.ANNA:
                    memString = JsonLoader.LoadJson("AnnaToDetective");
                    break;
                case Members.KENNETH:
                    memString = JsonLoader.LoadJson("KennethToDetective");
                    break;
                case Members.BLONTE:
                    memString = JsonLoader.LoadJson("BlonteToDetective");
                    break;
            }
            Queue<string> memberQueue = JsonConvert.DeserializeObject<Queue<string>>(memString);
            return memberQueue;
        }

        public Queue<string> GetMemberSpokenQue()
        {
            string memString = JsonLoader.LoadJson("MemberSpoken");
            Queue<string> memberQueue = JsonConvert.DeserializeObject<Queue<string>>(memString);
            return memberQueue;
        }
        #endregion --------------------

    }
}

