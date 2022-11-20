using Com.Afb.GridGame.Presentation.Interactor;
using Com.Afb.GridGame.Presentation.Presenter;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View {
    public class SizeView : MonoBehaviour {
        // Serialize Fields
        [SerializeField]
        private int minValue;
        [SerializeField]
        private int maxValue;
        [SerializeField]
        private TMP_InputField gridSizeInput;

        // Dependencies
        [Inject]
        private IGridSizePresenter gridSizePresenter;
        [Inject]
        private IGridSizeInteractor gridSizeInteractor;

        // Private Properties
        private int gridSize;

        // Unity Methods
        private void Awake() {
            gridSizePresenter.GridSize
                .TakeUntilDestroy(gameObject)
                .Subscribe(OnGridSizeUpdate);

            gridSizeInput.onValueChanged.AddListener(OnValueChanged);
            gridSizeInput.onEndEdit.AddListener(_ => SetGridSize());
        }

        // Private Methods
        private void OnGridSizeUpdate(int gridSize) {
            gridSizeInput.SetTextWithoutNotify(gridSize.ToString());
        }

        private void OnValueChanged(string value) {
            if (int.TryParse(value, out var gridSize)) {
                this.gridSize = gridSize;
            }
        }

        private int ValidateInput(int value) {
            if (value < minValue) {
                return minValue;
            }
            else if (value > maxValue) {
                return maxValue;
            }

            return value;
        }

        private void SetGridSize() {
            gridSize = ValidateInput(gridSize);
            gridSizeInteractor.SetGridSize(gridSize);
        }
    }
}
