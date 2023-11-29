using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysteryMayhem.Objects
{
    public enum ObjectType
    {
        BODY,
        COIN,
        RING,
        POTION
    }

    public class ObjectInfo : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private ObjectType objectType;
        [SerializeField] private List<string> historyList = new List<string>();
        [SerializeField] private string historyInfo;
        [SerializeField] private ObjectInfoView objectInfoView;
        #endregion --------------------

        #region ---------- Private Variables ----------
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        #endregion --------------------

        #region ---------- Private Methods ----------
        #endregion --------------------

        #region ---------- Public Methods ----------
        public List<string> GetHistoryList()
        {
            return historyList;
        }

        public string GetHistoryInfo()
        {
            return historyInfo;
        }
        #endregion --------------------
    }
}
