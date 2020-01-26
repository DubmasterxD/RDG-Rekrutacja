using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem deathPartciles =null;
    [SerializeField] Transform body =null;
    [SerializeField] Trigger spawnTrigger = null;
    [SerializeField] bool spawnAtStart = false;

    Animator animator;
    int _jumpAnimatorTrigger = Animator.StringToHash("Jump");
    int _dieAnimatorTrigger = Animator.StringToHash("Die");
    int _spawnAnimatorTrigger = Animator.StringToHash("Spawn");

    float randomJumpInterval = 1;
    float timer = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spawnTrigger.onTriggerEnter += Spawn;
    }

    private void Start()
    {
        if (!spawnAtStart)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= randomJumpInterval)
        {
            Jump();
            randomJumpInterval = Random.Range(1, 3);
            timer = 0;
        }
    }

    private void Jump()
    {
        animator.SetTrigger(_jumpAnimatorTrigger);
    }

    public void ReceiveHit()
    {
        Die();
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        animator.SetTrigger(_spawnAnimatorTrigger);
    }

    public void Died()
    {
        Instantiate(deathPartciles, body.position, new Quaternion(0, 0, 0, 1));
        gameObject.SetActive(false);
    }

    private void Die()
    {
        animator.SetTrigger(_dieAnimatorTrigger);
    }
}
