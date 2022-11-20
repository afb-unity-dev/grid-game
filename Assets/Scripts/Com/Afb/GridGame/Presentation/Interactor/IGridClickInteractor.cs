using UnityEngine;

namespace Com.Afb.GridGame.Presentation.Interactor {
    public interface IGridClickInteractor {
        // Methods
        void OnClickCell(Vector2Int cellPosition);
    }
}
