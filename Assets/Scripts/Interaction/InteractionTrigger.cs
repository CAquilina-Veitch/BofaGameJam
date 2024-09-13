using Scripts.Extensions;
using Scripts.Storage.Keybinds;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Scripts.Interaction
{
    public class InteractionTrigger : MonoBehaviour
    {
        [SerializeField] private InteractionType type;
        [SerializeField] private Collider2D trigger2D;
        private KeyCode interactionKey;

        private readonly SerialDisposable keyCheckSerialDisposable = new();

        private void Awake() => EstablishKeybind();

        #region Initializing

        private void EstablishKeybind()
        {
            var keybindingAttempt = StorageBindings.KeybindingData.GetKeybind(type);
            if (!keybindingAttempt.HasValue)
            {
                Debug.LogError($"Reading keybind {type} failed, read null.");
                return;
            }

            interactionKey = keybindingAttempt.Value.Key;
            trigger2D.OnCollisionEnter2DAsObservable().Subscribe(OnEnteredTriggerBox).AddTo(this);
            trigger2D.OnCollisionExit2DAsObservable().Subscribe(OnExitedTriggerBox).AddTo(this);
        }

        #endregion

        #region TriggerBox Behaviour

        private void OnEnteredTriggerBox(Collision2D collision2D)
        {
            //add if player logic
            Observable.EveryUpdate().Subscribe(CheckInputUpdateLoop).AssignTo(keyCheckSerialDisposable);
        }
        private void OnExitedTriggerBox(Collision2D collision2D)
        {
            //add if player logic
            keyCheckSerialDisposable.Disposable = null;
        }

        #endregion

        #region OnButtonPress Behaviour

        private void CheckInputUpdateLoop() 
        {
            if(Input.GetKeyDown(interactionKey))
                Interaction();
        }

        #endregion

        public virtual void Interaction()
        {

        }
        //maybe this should invoke an iobservable, so that different behaviour can be changed out. Im not quite sure.

        //example case is talking interaction, first starts dialogue, then does next next next etc. How.
    }
}