using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Platform : MonoBehaviour
{
    [SerializeField]
    private PlatformScriptable _scriptable;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _renderer.color = _scriptable.PlatformColor;
    }

    private void OnBecameInvisible()
    {
        if (this != null) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject collidingObject = other.gameObject;

        if (!collidingObject.CompareTag("Player"))
        {
            return;
        }

        Rigidbody2D rigidbody2D = collidingObject.GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody2D.velocity;

        if (velocity.y > 0f)
        {
            return;
        }

        velocity.y = _scriptable.JumpForce;
        rigidbody2D.velocity = velocity;

        if (_scriptable.IsBreakable)
        {
            Destroy(this.gameObject);
        }
    }
}
