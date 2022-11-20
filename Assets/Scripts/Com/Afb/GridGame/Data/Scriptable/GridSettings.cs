using UnityEngine;
using UnityEngine.Serialization;

namespace Com.Afb.GridGame.Data.Dto {
    [CreateAssetMenu(fileName = "GridSettings", menuName = "ScriptableObjects/GridSettings")]
    public class GridSettings : ScriptableObject {
        // Serialize Fields
        [SerializeField, FormerlySerializedAs("gridSize")]
        private int initialGridSize;

        // Public Properties
        public int GridSize => initialGridSize;
    }
}