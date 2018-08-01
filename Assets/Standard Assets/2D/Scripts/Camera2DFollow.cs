using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        private GameObject player;
        public float xMin = -200;
        public float xMax = 200;
        public float yMin = -200;
        public float yMax = 200;

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void LateUpdate()
        {
            float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }

        //public Transform target;
        //public float damping = 1;
        //public float lookAheadFactor = 3;
        //public float lookAheadReturnSpeed = 0.5f;
        //public float lookAheadMoveThreshold = 0.1f;

        //private float m_OffsetZ;
        //private Vector3 m_LastTargetPosition;
        //private Vector3 m_CurrentVelocity;
        //private Vector3 m_LookAheadPos;

        //// Use this for initialization
        //private void Start()
        //{
        //    m_LastTargetPosition = target.position;
        //    m_OffsetZ = (transform.position - target.position).z;
        //    transform.parent = null;
        //}


        //// Update is called once per frame
        //private void Update()
        //{
        //    // only update lookahead pos if accelerating or changed direction
        //    float xMoveDelta = (target.position - m_LastTargetPosition).x;

        //    bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        //    if (updateLookAheadTarget)
        //    {
        //        m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
        //    }
        //    else
        //    {
        //        m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
        //    }

        //    Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
        //    Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

        //    transform.position = newPos;

        //    m_LastTargetPosition = target.position;
        //}
    }
}
