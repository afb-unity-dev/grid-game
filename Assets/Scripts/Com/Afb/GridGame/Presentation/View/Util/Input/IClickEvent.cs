using System;

namespace Com.Afb.GridGame.Presentation.View.Util.InputHelper {
    public interface IClickEvent {
        public IObservable<InputData> Click { get; }
    }
}