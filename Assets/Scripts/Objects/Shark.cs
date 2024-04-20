using UnityEngine;

namespace aprilJam
{
  public class Shark : Obstacle
  {
    #region PARAMETERS
    [SerializeField] private Vector2 speedRange;
    [SerializeField] private Vector2 rotationSpeedRange;
    [SerializeField] private float   changeSpeedRate = 1f;
    [SerializeField] private float   chasingCooldown = 10f;
    [SerializeField] private float   attackDistance  = 13f;
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

    private Animator animator;
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
      animator          = GetComponentInChildren<Animator>();
      habitatZoneCenter = transform.position;

      InvokeRepeating("SetRandomSpeed", 0f, changeSpeedRate);
    }

    private void FixedUpdate()
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
      Invoke("StopCooldown", attackCooldown);
    }

    private void StopCooldown()
    {
      canAttack = true;
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
      Vector3 targetDirection = target.transform.position - transform.position;
      Vector3 sharkDirection  = Vector3.RotateTowards(transform.forward,
                                                      targetDirection,
                                                      speed * Time.deltaTime,
                                                      0.0f);
      // Debug.DrawRay(transform.position, sharkDirection, Color.red);
      transform.rotation = Quaternion.LookRotation(sharkDirection);

      if (targetDirection.magnitude < attackDistance)
      {
        isAttackFinished = false;
        animator.SetTrigger("Attack");
        Invoke("StartCooldown", 4.4f);
      }
    }

    protected override void ProcessTrigerCollision(Collider _collision)
    {
      target = _collision.gameObject;
      if (canAttack) StartChasing();
    }

    private void OnTriggerExit(Collider _collision)
    {
      target = null;
    }
    #endregion
  }
}
