using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType {
    NONE = 0,
    UP = 1,
    RIGHT = 1 << 1,     // 2
    DOWN = 1 << 2,      // 4
    LEFT = 1 << 3,      // 8
    JAB = 1 << 4,       // 16
    STRONG = 1 << 5,    // 32
    FIERCE = 1 << 6,    // 64
    SHORT = 1 << 7,     // 128
    FORWARD = 1 << 8,   // 256
    ROUNDHOUSE = 1 << 9 // 512
}

public class InputBuffer {
    public InputType CurrentInput { get { return m_inputBuffer[m_currentFrame]; } }
    
    private readonly InputType[] m_inputBuffer;
    private readonly int m_bufferSize = 12;
    private int m_currentFrame = 0;

    public InputBuffer() {
        m_inputBuffer = new InputType[m_bufferSize];
        for (int i = 0; i < m_bufferSize; i++) {
            m_inputBuffer[0] = InputType.NONE;
        }
    }

    public void AddInputToBuffer(InputType input) {
        m_inputBuffer[m_currentFrame] |= input;
    }

    public void ClearCurrentInput() {
        m_inputBuffer[m_currentFrame] = InputType.NONE;
    }

    public void IncrementFrame() {
        m_currentFrame++;
        m_currentFrame %= m_bufferSize;
    }
}
