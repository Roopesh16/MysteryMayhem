using MysteryMayhem.Detective.Powerup;
using UnityEngine;

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

        #region ---------- Public Variables ----------
        #endregion --------------------

        #region ---------- Monobehavior Methods ----------
        private void Awake()
        {
            detectiveAnim = GetComponent<Animator>();
            detectiveRb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            movementVec.x = Input.GetAxisRaw("Horizontal");
            movementVec.y = Input.GetAxisRaw("Vertical");
            movementVec = movementVec.normalized;

            detectiveAnim.SetFloat("Horizontal", movementVec.x);
            detectiveAnim.SetFloat("Vertical", movementVec.y);

            if(Input.GetMouseButtonDown(1))
            {
                StartCoroutine(powerup.EnableLieDetector());
            }
        }

        private void FixedUpdate()
        {
            detectiveRb.MovePosition((Vector2)transform.position + movementVec * moveSpeed * Time.fixedDeltaTime);
        }
        #endregion --------------------

        #region ---------- Private Methods ----------
        #endregion --------------------

        #region ---------- Public Methods ----------
        #endregion --------------------
    }
}
