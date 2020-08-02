/*     INFINITY CODE 2013-2019      */
/*   http://www.infinity-code.com   */

using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    /// <summary>
    /// Example of interception requests to download tiles
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/CustomDownloadTileExample")]
    public class CustomDownloadTileExample : MonoBehaviour
    {
        private OnlineMaps map;

        private void Start()
        {
            map = OnlineMaps.instance;

            // Subscribe to the tile download event.
            OnlineMapsTileManager.OnStartDownloadTile += OnStartDownloadTile;
        }

        private void OnStartDownloadTile(OnlineMapsTile tile)
        {
            Texture2D tileTexture = new Texture2D(256, 256);

            // Here your code to load tile texture from any source.

            // Apply your texture in the buffer and redraws the map.
            if (map.control.resultIsTexture)
            {
                // Apply tile texture
                (tile as OnlineMapsRasterTile).ApplyTexture(tileTexture as Texture2D);

                // Send tile to buffer
                map.buffer.ApplyTile(tile);

                // Destroy the texture, because it is no longer needed.
                OnlineMapsUtils.Destroy(tileTexture);
            }
            else
            {
                // Send tile texture
                tile.texture = tileTexture;

                // Change tile status
                tile.status = OnlineMapsTileStatus.loaded;
            }

            // Redraw map (using best redraw type)
            map.Redraw();
        }
    }
}