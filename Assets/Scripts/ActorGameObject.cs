using UnityEngine;

public class ActorGameObject : MonoBehaviour{
    public ActorData actorData;

    private Actor m_actor;
    private BattleController m_battleController;
    private CommandInterpreter m_commandInterpreter;

    private void Awake() {
        if(actorData != null) {
            actorData.InitializeCommands();
            m_actor = new Actor();
            m_battleController = new BattleController();
            m_commandInterpreter = new CommandInterpreter(actorData.Commands);
        }
    }

    private void FixedUpdate() {
        m_battleController.Update();
        m_commandInterpreter.ComposeCommands(m_battleController.InputBuffer.CurrentInput);
        m_commandInterpreter.ExcecuteCommands(m_actor);
        m_battleController.EndFrame();
    }

    private void OnDisable() {
        m_battleController.DisableControls();
    }

    private void OnEnable() {
        m_battleController.EnableControls();
    }
}
