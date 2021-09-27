using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CharacterMovementController : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField] private Rigidbody2D rb;

        [Header("Settings")]
        [SerializeField] private float jumpForce;
        [SerializeField] private float detectGroundLenght;

        [Header("Development setting")]
        [SerializeField] private bool showDetectGroundRay;



        private void Awake()
        {
            if (this.rb == null) this.rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (this.showDetectGroundRay)
            {
                Debug.DrawRay(transform.position, Vector3.down * this.detectGroundLenght, Color.red);
            }
        }
        public bool IsGround()
        {
            int groundLaterMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, this.detectGroundLenght, groundLaterMask);
            return hit.collider;
        }

        public void Jump() => this.rb.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
           
        

    }
}