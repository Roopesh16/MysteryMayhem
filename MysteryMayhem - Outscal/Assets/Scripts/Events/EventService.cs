namespace MysteryMayhem.Events
{
    public class EventService
    {
        #region ---------- Private Variables ----------
        private static EventService instance = null;
        #endregion --------------------

        #region ---------- Public Variables ----------
        public static EventService Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EventService();
                }

                return instance;
            }
        }

        public EventController OnConversationEnd { get; private set; }
        public EventController OnFinalDeduction { get; private set; }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public EventService()
        {
            OnConversationEnd = new EventController();
            OnFinalDeduction = new EventController();
        }
        #endregion --------------------
    }
}
