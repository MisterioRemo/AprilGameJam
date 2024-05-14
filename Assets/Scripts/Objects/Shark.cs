using System.Collections;
using UnityEngine;

namespace aprilJam
{
  public class Shark : Obstacle
  {
    #region PARAMETERS
    [SerializeField] private Vector2 speedRange;
    [SerializeField] private Vector2 rotationSpeedRange;
    [SerializeField] private float   changeSpeedRate = 1f;
    [SerializeField] private float   attackDistance  = 10f;
    [SerializeField] private float   attackCooldown  = 10f;

    [Header("Habitat zone")]
    [SerializeField] private float habitatZoneRadius;
    [SerializeField] private float habitatZonePadding = 1f;
    [SerializeField] private bool  DrawHabitatZone;

    private Vector3 habitatZoneCenter;
    private float   speed;
    private float   rotationSpeed;
    private Vector3 angles = Vector3.zero;

    private bool       isChasing;
    private GameObject target;
    private bool       isAttackFinished = true;
    private bool       canAttack        = true;

    private SphereCollider detectCollider;
    private Animator       animator;
    #endregion

    #region LIFECYCLE
    private void OnDrawGizmos()
    {
      if (DrawHabitatZone)
      {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, habitatZoneRadius);
      }
    }

    private void Awake()
    {
      detectCollider    = GetComponent<SphereCollider>();
      animator          = GetComponentInChildren<Animator>();
      habitatZoneCenter = transform.position;

      InvokeRepeating("SetRandomSpeed", 0f, changeSpeedRate);
    }

    private void Update()
    {
      if (!isAttackFinished)
        return;

      if (isChasing)
      {
        Chase();
      }
      else
      {
        float accCoef      = Vector3.Distance(transform.position, habitatZoneCenter) >= habitatZoneRadius - habitatZonePadding
                             ? 10f : 1f;
        angles.y          += accCoef * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(angles);
      }

      transform.Translate(Vector3.forward * speed * Time.deltaTime);
      transform.position = habitatZoneCenter + Vector3.ClampMagnitude(transform.position - habitatZoneCenter, habitatZoneRadius);
    }
    #endregion

    #region COLLISIONS
    protected override void ProcessCollision(Collision _collision)
    {
      if (canAttack)
        base.ProcessCollision(_collision);
    }

    protected override void ProcessTrigerCollision(Collider _collision)
    {
      target = _collision.gameObject;
      if (canAttack)
        StartChasing();
    }
    #endregion

    #region METHODS
    private void SetRandomSpeed()
    {
      if (isChasing)
        return;

      speed         = Random.Range(speedRange.x, speedRange.y);
      rotationSpeed = Random.Range(rotationSpeedRange.x, rotationSpeedRange.y);
    }

    private void StartCooldown()
    {
      canAttack        = false;
      isChasing        = false;
      isAttackFinished = true;
      target           = null;
      Invoke("StopCooldown", attackCooldown);
    }

    private void StopCooldown()
    {
      canAttack = true;
      DetectSailor();
      StartChasing();
    }

    private void StartChasing()
    {
      if (target == null)
        return;

      isChasing            = true;
      rotationSpeed        = rotationSpeedRange.y;
      speed                = speedRange.y;
    }

    private void Chase()
    {
      if (!isAttackFinished)
        return;

      Vector3 targetDirection = target.transform.position - transform.position;
      Vector3 sharkDirection  = Vector3.RotateTowards(transform.forward,
                                                      targetDirection,
                                                      speed * Time.deltaTime,
                                                      0.0f);
      // Debug.DrawRay(transform.position, sharkDirection, Color.red);
      transform.rotation = Quaternion.LookRotation(sharkDirection);

      if (targetDirection.magnitude < attackDistance)
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
      isAttackFinished = false;
      animator.SetTrigger("Dive");
      yield return new WaitForSeconds(3f);

      transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
      animator.SetTrigger("Attack");
      yield return new WaitForSeconds(2.2f);

      StartCooldown();
    }

    private void DetectSailor()
    {
      Collider[] hitColliders = Physics.OverlapSphere(detectCollider.center, detectCollider.radius);

      foreach (var hitCollider in hitColliders)
      {
        if (IsSailor(hitCollider.transform.root.gameObject))
        {
          target = hitCollider.gameObject;
          return;
        }
      }
    }
    #endregion
  }
}
