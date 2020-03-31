using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;

namespace GameUtils
{
    public class AddressableSpriteLoader : MonoBehaviour
    {
        public AssetReferenceSprite newSprite;
        private SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            newSprite.LoadAssetAsync().Completed += SpriteLoaded;
        }

        private void SpriteLoaded (AsyncOperationHandle<Sprite> obj)
        {
            switch(obj.Status)
            {
                case AsyncOperationStatus.Succeeded:
                    spriteRenderer.sprite = obj.Result;
                    break;
                case AsyncOperationStatus.Failed:
                    Debug.LogError("Sprite load failed.");
                    break;
                default:
                    break;
            }
        }
    }
}