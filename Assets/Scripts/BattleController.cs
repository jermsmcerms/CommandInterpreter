using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleController {
    public InputBuffer InputBuffer { get { return m_inputBuffer; } }
    private readonly InputBuffer m_inputBuffer;

    private readonly PlayerControls m_playerControls;

    public BattleController() {
        m_playerControls = new();
        m_playerControls.BattleControls.Jab.performed += OnJab;
        m_playerControls.BattleControls.Strong.performed += OnStrong;
        m_playerControls.BattleControls.Fierce.performed += OnFierce;
        m_inputBuffer = new();
    }

    public void DisableControls() {
        m_playerControls.BattleControls.Disable();
    }

    public void EnableControls() {
        m_playerControls.BattleControls.Enable();
    }

    public void EndFrame() {
        m_inputBuffer.IncrementFrame();
        m_inputBuffer.ClearCurrentInput();
    }

    public void Update() {
        AddDirectionalInputToBuffer();
    }

    private void AddDirectionalInputToBuffer() {
        Vector2 directionVector = m_playerControls.BattleControls.Movement.ReadValue<Vector2>();
        if(directionVector.y < 0.0f) {
            m_inputBuffer.AddInputToBuffer(InputType.DOWN);
        }
    }

    private void OnJab(InputAction.CallbackContext context) {
        m_inputBuffer.AddInputToBuffer(InputType.JAB);
    }

    private void OnStrong(InputAction.CallbackContext context) {
        m_inputBuffer.AddInputToBuffer(InputType.STRONG);
    }

    private void OnFierce(InputAction.CallbackContext context) {
        m_inputBuffer.AddInputToBuffer(InputType.FIERCE);
    }
}
