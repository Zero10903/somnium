using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTogglePlatforms : MonoBehaviour{

    private PlayerTogglePlatforms _playerTogglePlatforms;

    [Header("Platforms")]
    [SerializeField] private string _temporaryPlatformsTag = "TemporaryPlatform";
    [SerializeField] private string _movingPlatformsTag = "MovingPlatform";
    private bool _isDreamsDimensionActive = true;
    public bool IsDreamsDimensionActive => _isDreamsDimensionActive;

    // ? Set the temporary platforms active and the moving platforms inactive by default
    private void Start(){
        TogglePlatformsByTag(_temporaryPlatformsTag, true);
        TogglePlatformsByTag(_movingPlatformsTag, false);
    }

    private void Update(){

        // ? Toggle the platforms when the player presses the J key
        if(Input.GetKeyDown(KeyCode.J)){

            _isDreamsDimensionActive = !_isDreamsDimensionActive;

            TogglePlatformsByTag(_temporaryPlatformsTag, _isDreamsDimensionActive);
            TogglePlatformsByTag(_movingPlatformsTag, !_isDreamsDimensionActive);
        }
    }

    // ? Toggle the platforms by tag
    private void TogglePlatformsByTag(string tag, bool isActive){

        GameObject[] platforms = GameObject.FindGameObjectsWithTag(tag);

        // ? Disable the sprite renderer and collider of the platform
        foreach (GameObject platform in platforms){
            
            var temporaryPlatforms = platform.GetComponent<TemporaryPlatforms>();
            if (temporaryPlatforms != null && temporaryPlatforms.IsReactivating){
                continue;
            }

            var spriteRenderer = platform.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null){
                spriteRenderer.enabled = isActive;
            }

            var collider = platform.GetComponent<Collider2D>();
            if (collider != null){
                collider.enabled = isActive;
            }
        }
    }
}
