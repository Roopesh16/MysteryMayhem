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
        [SerializeField] private List<string> historyString = new List<string>();
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
        #endregion --------------------
    }
}
