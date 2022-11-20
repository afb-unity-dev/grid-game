using Com.Afb.GridGame.Presentation.Presenter;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View {
    public class ScoreView : MonoBehaviour {
        // Seriazlie Fields
        [SerializeField]
        private TMP_Text scoreValue;

        // Dependencies
        [Inject]
        private IGridScorePresenter gridScorePresenter;

        private void Awake() {
            gridScorePresenter.GridScore
                .TakeUntilDestroy(gameObject)
                .Subscribe(SetScore);
        }

        private void SetScore(int score) {
            scoreValue.text = score.ToString();
        }
    }
}
