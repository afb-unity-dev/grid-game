using Com.Afb.GridGame.Presentation.View.Util;
using Com.Afb.GridGame.Presentation.View.Util.InputHelper;
using UniRx;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View {
    public class ClickControllerView : MonoBehaviour {
        // Dependencies
        [Inject]
        private IClickEvent clickEvent;

        private void Awake() {
            clickEvent.Click
                .TakeUntilDestroy(gameObject)
                .Subscribe(OnClick);
        }

        private void OnClick(InputData input) {
            RaycastHit2D[] hits = PhysicsCast.CircleCastScreenPosition(input.position,
                Camera.main,
                LayerMask.GetMask("Grid"));

            if (hits.Length > 0) {
                IClickableView first = null;

                for (int i = 0; i < hits.Length; i++) {
                    RaycastHit2D hit = hits[i];
                    IClickableView tmp = hit.collider.GetComponent<IClickableView>();

                    if (tmp != null) {
                        first = tmp;
                        break;
                    }
                }

                if (first != null) {
                    first.Click();
                }
            }
        }
    }
}
