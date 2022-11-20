using Com.Afb.GridGame.Presentation.View.Util.Extensions;
using UnityEngine;

namespace Com.Afb.GridGame.Presentation.View {
    public class GridContent : MonoBehaviour {
        // SerializeFields
        [SerializeField, Range(0, 1)]
        private float marginTop;
        [SerializeField, Range(0, 1)]
        private float marginBottom;
        [SerializeField, Range(0, 1)]
        private float marginLeft;
        [SerializeField, Range(0, 1)]
        private float marginRigth;

        // Private Properties
        private Bounds bounds;

        // Public Properties
        public Bounds Bounds => bounds;

        private void Awake() {
            SetBounds();
        }

        private void OnDrawGizmos() {
            SetBounds();

            float minX = bounds.min.x;
            float maxX = bounds.max.x;
            float minY = bounds.min.y;
            float maxY = bounds.max.y;

            Gizmos.DrawCube(new Vector3(minX, minY, 0), new Vector3(0.5f, 0.5f, 0.5f));
            Gizmos.DrawCube(new Vector3(minX, maxY, 0), new Vector3(0.5f, 0.5f, 0.5f));
            Gizmos.DrawCube(new Vector3(maxX, minY, 0), new Vector3(0.5f, 0.5f, 0.5f));
            Gizmos.DrawCube(new Vector3(maxX, maxY, 0), new Vector3(0.5f, 0.5f, 0.5f));

            Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(minX, maxY, 0));
            Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(maxX, maxY, 0));
            Gizmos.DrawLine(new Vector3(maxX, maxY, 0), new Vector3(maxX, minY, 0));
            Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(minX, minY, 0));
        }

        private void SetBounds() {
            Bounds cameraBounds = Camera.main.OrthographicBounds();

            float camWidth = cameraBounds.max.x - cameraBounds.min.x;
            float camHeight = cameraBounds.max.y - cameraBounds.min.y;
            float top = camHeight * marginTop;
            float bottom = camHeight * marginBottom;
            float left = camWidth * marginLeft;
            float right = camWidth * marginRigth;

            float width = camWidth - left - right;
            float height = camHeight - top - bottom;

            float size = Mathf.Min(width, height);

            var x = transform.position.x + left / 2 - right / 2;
            var y = transform.position.y - top / 2 + bottom / 2;
            bounds = new Bounds(new Vector3(x, y, 0), new Vector3(size, size, 0));
        }
    }
}