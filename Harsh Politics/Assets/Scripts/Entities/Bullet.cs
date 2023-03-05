using SupportFiles;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletDecay = 5f;

        private int bulletDamage;

        private Rigidbody2D bulletBody;

        private FaceDirection _faceDirection;
        void Start()
        {
            bulletBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            bulletDecay -= 1 * Time.deltaTime;
            if (bulletDecay <= 0f)
            {
                bulletDestroy();
            }

            if (_faceDirection == FaceDirection.Left)
            {
                bulletBody.AddForce(Vector2.left*10,ForceMode2D.Force);
            }
            else
            {
                bulletBody.AddForce(Vector2.right*10,ForceMode2D.Force);
            }
        }
        void bulletDestroy()
        {
            Destroy(gameObject);
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            bulletDestroy();
        }

        public int BulletDamage()
        { 
            return bulletDamage;
        }

        public void SetBulletDamage(int damage)
        {
            bulletDamage = damage;
        }

        public void CurrentFaceDirection(FaceDirection direction)
        {
            _faceDirection = direction;
        }
    }
    
}