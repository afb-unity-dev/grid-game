using UnityEngine;

namespace Com.Afb.GridGame.Data.Dto {
    [CreateAssetMenu(fileName = "GridSettings", menuName = "ScriptableObjects/GridSettings")]
    public class GridSettings : ScriptableObject {
        // Serialize Fields
        [SerializeField]
        private int gridSize;

        // Public Properties
        public int GridSize => gridSize;
    }
}