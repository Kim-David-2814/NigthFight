using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NightFight.input
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed; // скорость
        [SerializeField] private float _jumpForse; // сила прыжка
        [SerializeField] private float _groundCheckRadius; // радиус колойдера для прповерки земли

        private float _moveX; // движение по иксу

        private Animator _anim;
        private Rigidbody2D _rb;
        public LayerMask _ground; //слой земли
        public Transform _groundCheck; //проверка земли

        public bool _onGround; // на земле ли персонаж
        public bool _useWASD; // какой котроллер использует игрок
        public bool _faceRight = true; // в какую сторону смотрит персонаж

        public void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            Walk();
            Reflec();
            Jump();
        }

        //метод ля ходьбы
        public void Walk()
        {
            if (_useWASD)
            {
                _moveX = Input.GetAxis(GlobalStringVars._horizontalWASD);
                transform.position += new Vector3(_moveX, 0, 0) * _speed * Time.deltaTime;

                _anim.SetFloat("MoveHero1", Mathf.Abs(_moveX));
            }
            else
            {
                _moveX = Input.GetAxis(GlobalStringVars._horizontalAxis);
                transform.position += new Vector3(_moveX, 0, 0) * _speed * Time.deltaTime;

                _anim.SetFloat("MoveHero3", Mathf.Abs(_moveX));
            }
        }
        
        // проверка земли и прыжок
        public void Jump()
        {
            CheckGrounded();

            if (_useWASD)
            {
                if (_onGround && Input.GetKey(KeyCode.Space))
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForse);
                    _anim.SetTrigger("OnGroundHero1");
                }
            }
            else
            {
                if (_onGround && Input.GetKey(KeyCode.L))
                {
                    _rb.AddForce(new Vector2(0, _jumpForse), ForceMode2D.Impulse);
                    _anim.SetTrigger("OnGroundHero3");
                }
            }
        }

        // проверка земли 
        void CheckGrounded()
        {
            _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);
        }

        // поворт персонажа по иксу
        public void Reflec()
        {
            if ((_moveX > 0 && !_faceRight) || (_moveX < 0 && _faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);
                _faceRight = !_faceRight;
            }
        }

        // чтобы легче видететь где рассположен радиус колайдера косающегося земли
        void OnDrawGizmos()
        {
            if (_groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(_groundCheck.position, _groundCheckRadius);
            }
        }
    }

}
