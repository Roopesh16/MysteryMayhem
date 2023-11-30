using UnityEngine;
using MysteryMayhem.Manager;
using MysteryMayhem.Detective.Powerup;

namespace MysteryMayhem.Detective
{
    public class DetectiveController : MonoBehaviour
    {
        #region ---------- Serialized Variables ----------
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private PowerupController powerup;
        #endregion --------------------

        #region ---------- Private Variables ----------
        private Animator detectiveAnim;
        private Rigidbody2D detectiveRb;
        private Vector2 movementVec;
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            detectiveAnim = GetComponent<Animator>();
            detectiveRb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (GameManager.Instace.GetGameState() == GameState.PLAY)
            {
                movementVec.x = Input.GetAxisRaw("Horizontal");
                movementVec.y = Input.GetAxisRaw("Vertical");
                movementVec = movementVec.normalized;

                detectiveAnim.SetFloat("Horizontal", movementVec.x);
                detectiveAnim.SetFloat("Vertical", movementVec.y);
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.Instace.GetGameState() == GameState.PLAY)
            {
                detectiveRb.MovePosition((Vector2)transform.position + movementVec * moveSpeed * Time.fixedDeltaTime);
            }
        }
        #endregion --------------------

        #region ---------- Public Methods ----------
        public void DisplayLieDetector()
        {
            StartCoroutine(powerup.EnableLieDetector());
        }
        #endregion --------------------
    }
}
