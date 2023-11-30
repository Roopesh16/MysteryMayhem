using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using MysteryMayhem.Manager;
using MysteryMayhem.Detective.Deduction;
using MysteryMayhem.Events;

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
        [Header("History Info")]
        [SerializeField] private ObjectType objectType = ObjectType.NULL;
        [SerializeField] private List<string> historyList = new List<string>();
        [SerializeField] private string historyInfo;
        [SerializeField] private ObjectInfoView objectInfoView;
        [SerializeField] private Button infoButton;
        [SerializeField] private Transform detectivePos;
        [SerializeField] private float minDistance = 2f;

        [Header("References")]
        [SerializeField] private DeductionController deductionController;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private bool canShowInfo = false;
        private int clickCount = 0;
        #endregion --------------------

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            infoButton.onClick.AddListener(InfoButton);
            infoButton.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            EventService.Instance.OnFinalDeduction.AddListener(DisableInfoButton);
        }

        private void OnDisable()
        {
            EventService.Instance.OnFinalDeduction.RemoveListener(DisableInfoButton);
        }

        private void Update()
        {
            if (GameManager.Instace.GetGameState() == GameState.PLAY)
            {
                if (Vector2.Distance(detectivePos.position, transform.position) <= minDistance && !canShowInfo)
                {
                    canShowInfo = true;
                    objectInfoView.SetObjectType(objectType);
                    infoButton.gameObject.SetActive(true);
                }
                else if (Vector2.Distance(detectivePos.position, transform.position) > minDistance && canShowInfo)
                {
                    objectInfoView.SetObjectType(ObjectType.NULL);
                    canShowInfo = false;
                    infoButton.gameObject.SetActive(false);
                }
            }
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        private void InfoButton()
        {
            clickCount++;
            if (clickCount == 1)
            {
                deductionController.IncrementDeductions(true);
            }
            infoButton.gameObject.SetActive(false);
            objectInfoView.DisplayHistoryBox();
            GameManager.Instace.SetGameState(GameState.DEDUCTION);
        }

        private void DisableInfoButton()
        {
            infoButton.gameObject.SetActive(false);
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
