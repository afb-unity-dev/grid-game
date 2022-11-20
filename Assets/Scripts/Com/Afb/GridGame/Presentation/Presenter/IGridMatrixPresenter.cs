using System.Collections.Generic;
using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridMatrixPresenter {
        // Properties
        IReadOnlyReactiveProperty<List<List<bool>>> GridMatrix { get; }
    }
}