using UnityEngine;

namespace Com.Afb.GridGame.Presentation.Interactor {
    public interface IGridClickInteractor {
        void OnClickCell(Vector2Int cellPosition);
    }
}
