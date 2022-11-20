using UnityEngine;

namespace Com.Afb.GridGame.Presentation.View.Util {
    public class PhysicsCast {
        private const float RADIUS = 0.02f;

        public static RaycastHit2D[] CircleCastScreenPosition(Vector2 position, Camera camera, int layerMask) {
            Vector2 worldPos = camera.ScreenToWorldPoint(new Vector3(position.x, position.y, camera.nearClipPlane));
            return Physics2D.CircleCastAll(worldPos, RADIUS, Vector2.zero, 0, layerMask);
        }

        public static RaycastHit2D[] CircleCastScreenPosition(Vector2 position, Camera camera) {
            Vector2 worldPos = camera.ScreenToWorldPoint(new Vector3(position.x, position.y, camera.nearClipPlane));
            return Physics2D.CircleCastAll(worldPos, RADIUS, Vector2.zero, 0);
        }
    }
}