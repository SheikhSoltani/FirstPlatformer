using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Collider2D _collider;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [Header("Settings")]
    [SerializeField]
    private float _walkSpeed = 1;

    [SerializeField]
    private float _animationsSpeed = 3;

    [SerializeField]
    private float _jumpStartSpeed = 2;

    [SerializeField]
    private float _movingTresh = 0.1f;

    [SerializeField]
    private float _flyTresh = 0.3f;

    [SerializeField]
    private float _bonusCount = 0f;


    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public float WalkSpeed => _walkSpeed;
    public float AnimationsSpeed => _animationsSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float MovingTresh => _movingTresh;
    public float FlyTresh => _flyTresh;
    public float BonusCount => _bonusCount;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigidbody => _rigidbody;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bonus")
        {
            Debug.Log("Bonus");

            _bonusCount++;
            col.gameObject.SetActive(false);
            //this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }
    }
}
