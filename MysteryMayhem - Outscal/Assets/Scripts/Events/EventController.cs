using System;

namespace MysteryMayhem.Events
{
    public class EventController
    {
        #region ---------- Public Variables ----------
        public event Action baseEvent;
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void InvokeEvent() => baseEvent?.Invoke();
        public void AddListener(Action listener) => baseEvent += listener;
        public void RemoveListener(Action listener) => baseEvent -= listener;
        #endregion --------------------
    }
}
