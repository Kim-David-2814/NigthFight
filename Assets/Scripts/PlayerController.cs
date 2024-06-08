using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NightFight.input
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForse;
        [SerializeField] private float _groundCheckRadius;

        private float _moveX;

        private Animator _anim;
        private Rigidbody2D _rb;
        public LayerMask _ground;
        public Transform _groundCheck;

        public bool _onGround;
        public bool _useWASD;
        public bool _faceRight = true;

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

        void CheckGrounded()
        {
            _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);
        }

        public void Reflec()
        {
            if ((_moveX > 0 && !_faceRight) || (_moveX < 0 && _faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);
                _faceRight = !_faceRight;
            }
        }

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
