using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MysteryMayhem.Dialogue
{
    public class DialogueLoader : MonoBehaviour
    {
        #region ---------- Public Methods ----------
        public Queue<string> GetDetBeginQueue()
        {
            string detString = JsonLoader.LoadJson("DetectiveBegin");
            List<string> detList = JsonConvert.DeserializeObject<List<string>>(detString);
            Queue<string> detectiveQueue = ListToQueue(detList);
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
            List<string> detList = JsonConvert.DeserializeObject<List<string>>(detString);
            Queue<string> detectiveQueue = ListToQueue(detList);
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
            List<string> memList = JsonConvert.DeserializeObject<List<string>>(memString);
            Queue<string> memberQueue = ListToQueue(memList);
            return memberQueue;
        }

        public Queue<string> GetMemberSpokenQue()
        {
            string memString = JsonLoader.LoadJson("MemberSpoken");
            List<string> memList = JsonConvert.DeserializeObject<List<string>>(memString);
            Queue<string> memberQueue = ListToQueue(memList);
            return memberQueue;
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private Queue<string> ListToQueue(List<string> list)
        {
            Queue<string> lineQ = new();
            foreach (string line in list)
            {
                lineQ.Enqueue(line);
            }

            return lineQ;
        }
        #endregion --------------------
    }
}



