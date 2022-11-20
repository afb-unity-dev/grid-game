using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Com.Afb.GridGame.Presentation.View {
    public class GridCellMarkView : MonoBehaviour {
        // Public Methods
        public void SetImage(Vector2 center, Vector2 size) {
            var renderer = GetComponent<SpriteRenderer>();

            renderer.size = size;
            transform.position = center;
        }

        public void Show(bool show) {
            if (gameObject.activeInHierarchy != show) {
                if (show) {
                    In();
                }
                else {
                    Out();
                }
            }
        }

        public void SetActive(bool active) {
            gameObject.SetActive(active);
        }

        // Private Methods
        private void In() {
            SetActive(true);
            var animator = GetComponent<Animator>();
            animator.Play("In");
        }

        private void Out() {
            var animator = GetComponent<Animator>();
            animator.GetBehaviour<ObservableStateMachineTrigger>()
                .OnStateEnterAsObservable()
                .TakeUntilDisable(gameObject)
                .Subscribe(_ => SetActive(false));
            animator.Play("Out");
        }
    }
}
