using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using MysteryMayhem.Manager;

namespace MysteryMayhem.Objects
{
    public enum ObjectType
    {
        BODY,
        COIN,
        RING,
        NULL
    }

    public class ObjectInfo : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private ObjectType objectType;
        [SerializeField] private List<string> historyList = new List<string>();
        [SerializeField] private string historyInfo;
        [SerializeField] private ObjectInfoView objectInfoView;
        [SerializeField] private Button infoButton;
        [SerializeField] private Transform detective;
        [SerializeField] private float minDistance = 2f;
        #endregion --------------------

        #region ---------- Private Variables ----------
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            infoButton.onClick.AddListener(InfoButton);
            infoButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (GameManager.Instace.GetGameState() == GameState.PLAY)
            {
                if (Vector3.Distance(detective.position, transform.position) <= minDistance)
                {
                    infoButton.gameObject.SetActive(true);
                }
                else
                {
                    infoButton.gameObject.SetActive(false);
                }
            }
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void InfoButton()
        {
            infoButton.gameObject.SetActive(false);
            objectInfoView.DisplayHistoryBox(objectType);
            GameManager.Instace.SetGameState(GameState.DEDUCTION);
        }
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
