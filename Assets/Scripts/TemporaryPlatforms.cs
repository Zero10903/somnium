using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPlatforms : MonoBehaviour {

    private PlayerTogglePlatforms _playerTogglePlatforms;

    [Header("Temporary Platforms")]
    [SerializeField] private float _timeToDeactivate = 2.0f;
    [SerializeField] private float _timeToActivate = 1f;
    private bool _isActive;
    private bool _canDeactivate;
    private bool _isReactivating;
    public bool IsReactivating => _isReactivating;

    private void Awake(){
        _isActive = true;
        _canDeactivate = true;
        _isReactivating = false;
        _playerTogglePlatforms = FindObjectOfType<PlayerTogglePlatforms>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player") && _canDeactivate == true){
            _canDeactivate = false;
            StartCoroutine(DeactivatePlatform());
        }
    }

    private IEnumerator DeactivatePlatform(){
        yield return new WaitForSeconds(_timeToDeactivate);
        _isActive = false;
        _isReactivating = true;
        
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null){
            spriteRenderer.enabled = _isActive;
        }

        var collider = GetComponent<Collider2D>();
        if(collider != null){
            collider.enabled = _isActive;
        }

        StartCoroutine(ActivatePlatform());
    }

    private IEnumerator ActivatePlatform(){

        yield return new WaitForSeconds(_timeToActivate);
        while(!_playerTogglePlatforms.IsDreamsDimensionActive){
            yield return null;
        }
        _isActive = true;
        _canDeactivate = true;
        _isReactivating = false;
        
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null){
            spriteRenderer.enabled = _isActive;
        }

        var collider = GetComponent<Collider2D>();
        if(collider != null){
            collider.enabled = _isActive;
        }
    }
}
