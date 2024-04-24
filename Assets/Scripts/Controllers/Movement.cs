using System.Collections;
using UnityEngine;

namespace aprilJam
{
  public class Movement : MonoBehaviour
  {
    #region PARAMETERS
    private Animator        animator;
    private CapsuleCollider bodyCollider;

    private float movingTime = 0.45f;
    private float speed      = 10f;

    // private float isNotControlTime = 5;
    private bool  isSkiping;
    private bool  canSkip;
    private float skipingTime = 0.5f;

    private Coroutine rotCoroutine;
    private bool      isRotating = false;
    [SerializeField] private float rotSpeed   = 50f;
    #endregion



    #region LIFECYCLE
    void Start()
    {
      animator     = GetComponentInChildren<Animator>();
      bodyCollider = GetComponentInChildren<CapsuleCollider>();
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
    #endregion

    #region INTERFACE
    public void isControls()
    {
      //if (isControl == false)
      //{
      //  animator.SetBool("Stop", true);
      //  StartRotations90();
      //  StartRotations15();
      //  isMoving = true;
      //  animator.SetBool("FrontCrawl", true);
      //}
    }

    public void Dive()
    {
      animator.SetTrigger("Drive");
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

    public void StartRotations(float _angle)
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

      while (transform.rotation != endRotation)
      {
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, time);
        time              += coef * rotSpeed * Time.deltaTime;

        yield return new WaitForEndOfFrame();
      }

      isRotating = false;
    }

    public void StartRotations90()
    {
      StartRotations(90);
    }

    public void StartRotations15()
    {
      StartRotations(15);
    }

    public void StartRotationsMinus90()
    {
      StartRotations(-90);
    }

    public void StartRotationsMinus15()
    {
      StartRotations(-15);
    }
    public void TurnAround()
    {
      StartRotations(180);
    }
    #endregion
  }
}


