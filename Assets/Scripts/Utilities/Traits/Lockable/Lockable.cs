using UnityEngine;

public class Lockable : MonoBehaviour
{
    private bool _lockItem;   
    
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private Collider2D _consumeCollider = null;
    [SerializeField] private Rigidbody2D _rb = null;

	public bool IsLocked() {
        return _lockItem;
    }
    
    public void LockAndHide() {
        _lockItem = true;
        
        if(_spriteRenderer != null)
            _spriteRenderer.enabled = false;

        if(_rb != null)
            _rb.gravityScale = 0;
        
        if(_consumeCollider != null)
            _consumeCollider.enabled = false;
    }
}