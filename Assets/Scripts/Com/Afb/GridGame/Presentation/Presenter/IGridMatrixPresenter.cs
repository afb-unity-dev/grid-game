using System.Collections.Generic;
using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridMatrixPresenter {
        IReadOnlyList<IReadOnlyList<IReadOnlyReactiveProperty<bool>>> GridMatrix { get; }
    }
}