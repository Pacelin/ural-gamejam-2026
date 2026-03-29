using Cysharp.Threading.Tasks;
using Plugins.Audio;
using Project.Core.Audio;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class ChechikGiveCardState : ChechikState
    {
        private static readonly int IsGive = Animator.StringToHash("is_give");

        public ChechikGiveCardState(ChechikAgent agent, ChechikStateMachine stateMachine) : base(agent, stateMachine)
        {
        }

        public override void OnEnterState()
        {
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                await UniTask.Delay(System.TimeSpan.FromSeconds(Agent.AppearCallDelay),
                    cancellationToken: cancellationToken);
                
                cancellationToken.ThrowIfCancellationRequested();
                Agent.SubtitlesService.Show(Agent.AppearText);
                Agent.AppearSound.PlayOneShot();
            }, Agent.GetCancellationTokenOnDestroy());
            
            Agent.MovementService.DisableMovement();
            Agent.Animator.SetBool(IsGive, true);
            Agent.FloppyPickup.SetActive(true);
            MusicController.SetRoomTone(AudioSystem.Game_Misc_RoomToneBunker);
        }

        public override void OnExitState()
        {
            Agent.MovementService.EnableMovement();
            Agent.Animator.SetBool(IsGive, false);
        }

        public override void OnAnimatorMove()
        {
        }

        public override void OnUpdate()
        {
            if (Agent.FloppyPickup)
                return;

            StateMachine.SwitchState(new ChechikRotateToState(Agent, StateMachine,
                Agent.GetLookAt(Agent.SlotPoint),
                new ChechikMoveToState(Agent, StateMachine,
                    Agent.SlotPoint.position,
                    new ChechikRotateToState(Agent, StateMachine,
                        Agent.SlotPoint.rotation,
                        new ChechikPointToSlotState(Agent, StateMachine)))
            ));
        }
    }
}