using UnityEngine;

namespace Com.Afb.GridGame.Presentation.View.Util.Extensions {
    public static class CameraExtensions {
        // Public Functions
        public static Bounds OrthographicBounds(this Camera camera) {
            var t = camera.transform;
            var x = t.position.x;
            var y = t.position.y;
            var size = camera.orthographicSize * 2;
            var width = size * camera.aspect;
            var height = size;

            return new Bounds(new Vector3(x, y, 0), new Vector3(width, height, 0));
        }
    }
}
