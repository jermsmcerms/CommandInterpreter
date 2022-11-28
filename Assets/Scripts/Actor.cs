public class Actor {
    public enum MovementState {
        JUMP,
        STAND,
        CROUCH
    }

    public MovementState MovmentState { get { return m_movmenetState; } }
    private MovementState m_movmenetState;

    public Actor() {
        m_movmenetState = MovementState.STAND;
    }

    public void UpdateMovmenetState(MovementState newState) {
        if (newState != m_movmenetState) {
            m_movmenetState = newState;
        }
    }
}
