using System.Collections;
using UnityEngine;

namespace aprilJam
{
  public class SailorMovement : MonoBehaviour
  {
    #region PARAMETERS
    private Animator        animator;
    private CapsuleCollider bodyCollider;
    private Rigidbody       rb;

    private float movingTime = 0.45f;
    private float speed      = 10f;

    private bool  isSkiping;
    private bool  canSkip;
    private float skipingTime = 0.5f;

    private Coroutine rotCoroutine;
    private bool      isRotating = false;

    [SerializeField] private float rotSpeed = 50f;
    #endregion

    #region LIFECYCLE
    void Start()
    {
      animator     = GetComponentInChildren<Animator>();
      bodyCollider = GetComponentInChildren<CapsuleCollider>();
      rb           = GetComponent<Rigidbody>();
    }
    #endregion

    #region COLLISIONS
    private void OnTriggerEnter(Collider _other)
    {
      if (_other.CompareTag("SkipRock"))
        canSkip = true;
    }

    private void OnTriggerExit(Collider _other)
    {
      if (_other.CompareTag("SkipRock"))
        canSkip = false;
    }

    private void OnCollisionEnter(Collision _collision)
    {
      rb.velocity = Vector3.zero;
    }
    #endregion

    #region INTERFACE
    public void TakeControl()
    {
      // Empty
    }

    public void Dive()
    {
      animator.SetTrigger("Dive");
    }

    public void Skip()
    {
      if (!canSkip)
        return;

      isSkiping = true;
      animator.SetTrigger("Skip");
      StartCoroutine(SkipCorutine());
    }

    private IEnumerator SkipCorutine()
    {
      float time    = 0f;
      bodyCollider.enabled = false;

      while (time < skipingTime)
      {
        transform.position += transform.forward * Time.deltaTime * speed;
        time               += Time.deltaTime;

        yield return new WaitForEndOfFrame();
      }

      bodyCollider.enabled = true;
      isSkiping            = false;
      canSkip              = false;
    }

    public void Move()
    {
      if (isSkiping) return;
      if (isRotating) StopCoroutine(rotCoroutine);

      animator.SetBool("Stop", false);
      animator.SetBool("Breaststroke", true);
      StartCoroutine(MovementCorutine());
    }

    private IEnumerator MovementCorutine()
    {
      float time = 0f;

      while (time < movingTime)
      {
        transform.position += transform.forward * Time.deltaTime * speed;
        time               += Time.deltaTime;

        yield return new WaitForEndOfFrame();
      }

      animator.SetBool("Breaststroke", false);
      animator.SetBool("Stop", true);
    }

    public void Rotate(float _angle)
    {
      if (isSkiping) return;
      if (isRotating) StopCoroutine(rotCoroutine);

      isRotating = true;
      animator.SetBool("Stop", true);
      rotCoroutine = StartCoroutine(RotaionCorutine(_angle));
    }
    private IEnumerator RotaionCorutine(float _angle)
    {
      Quaternion startRotation = transform.rotation;
      Quaternion endRotation   = Quaternion.Euler(0, transform.eulerAngles.y + _angle, 0);
      float      time          = 0f;
      float      coef          = 1f / Mathf.Abs(_angle);

      while (time < 1f)
      {
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, time);
        time              += coef * rotSpeed * Time.deltaTime;

        yield return new WaitForEndOfFrame();
      }

      isRotating = false;
    }

    public void RotateBy90Clockwise()
    {
      Rotate(90f);
    }

    public void RotateBy15Clockwise()
    {
      Rotate(15f);
    }

    public void RotateBy90Anticlockwise()
    {
      Rotate(-90f);
    }

    public void RotateBy15Anticlockwise()
    {
      Rotate(-15f);
    }
    public void TurnAround()
    {
      Rotate(180f);
    }
    #endregion
  }
}


