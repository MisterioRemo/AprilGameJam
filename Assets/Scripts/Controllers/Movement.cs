using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace aprilJam
{
    public class Movement : MonoBehaviour
    {
        private bool isMoving;
        private float movingTime = 0.75f;
        private float carrentMove = 0;
        private Animator animator;
        private bool isRotating;

        private float RotTime = 0.3f;
        private float LerpTime = 0;

        private float isNotControlTime = 5;
        private float LongJump = 3;


        private Quaternion startRotation;
        private Quaternion endRotation;

        public bool isControl { get; set; }

        private bool dive;

         



        void Start()
        {
            animator = GetComponent<Animator>();
         
        }

        

        public void isControls()
        {
            if (isControl == false)
            {
                animator.SetBool("Stop", true);
                StartRotations90();
                StartRotations45();
                isMoving = true;
                animator.SetBool("FrontCrawl", true);

            }
        }

        public void Dive()
        {
            dive = true;
            animator.SetBool("Stop", false);
            animator.SetBool("Drive", true);

        }

        public void Skip()
        {


            animator.SetTrigger("Skip");
            transform.position += Vector3.forward * LongJump;


        }



        void Rotation()
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, LerpTime);
            LerpTime += RotTime * Time.deltaTime;

            if (transform.rotation == endRotation)
                isRotating = false;

        }
        public void StartMovement()
        {
            isMoving = true;
            animator.SetBool("Stop", false);
            animator.SetBool("Breaststroke", true);
        }
        public void StartRotations(float Angle)
        {
            isRotating = true;
            animator.SetBool("Stop", true);
            startRotation = transform.rotation;
            endRotation = Quaternion.Euler(0, transform.eulerAngles.y + Angle, 0);
            LerpTime = 0;

        }
        public void StartRotations90()
        {
            StartRotations(90);
        }
        public void StartRotations45()
        {
            StartRotations(45);
        }
        public void StartRotationsMinys90()
        {
            StartRotations(-90);
        }
        public void StartRotationsMinys45()
        {
            StartRotations(-45);
        }


        void Update()
        {
            if (isMoving)
            {
                transform.position += transform.forward * Time.deltaTime * 10;

                carrentMove += Time.deltaTime;
                if (carrentMove >= movingTime)
                {
                    isMoving = false;
                    animator.SetBool("Breaststroke", false);
                    animator.SetBool("Stop", true);
                    carrentMove = 0;
                }

            }
            if (isRotating)
            {
                Rotation();
            }
        

        }
    }
}
   

       