using UnityEngine;

namespace Com.Afb.GridGame.Data.Dto {
    [CreateAssetMenu(fileName = "GridSettings", menuName = "ScriptableObjects/GridSettings")]
    public class GridSettings : ScriptableObject {
        [SerializeField]
        private int gridSize;
    }
}