using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Input
{
    public class GameplayActionsRegistrar : PlayerActions.IGameplayActions
    {
        public event Action<float> Move;

        public GameplayActionsRegistrar(PlayerActions.GameplayActions gameplayActions)
        {
            gameplayActions.SetCallbacks(this);
        }
    
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed || context.canceled)
            {
                float value = context.ReadValue<float>();
                Move?.Invoke(value);
            }
        }
    
    }
}
