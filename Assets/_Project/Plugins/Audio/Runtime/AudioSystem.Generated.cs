// ReSharper disable RedundantUsingDirective
#pragma warning disable CS1998

using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using FMODUnity;
using UnityEngine;

namespace Plugins.Audio
{
    public static partial class AudioSystem
    {
		public static class Global
		{
			public enum ELabel_PauseState
			{
				NotOnPause = 0,
				OnPause = 1,
			}
			private static readonly FMOD.Studio.PARAMETER_ID PauseStateId = new FMOD.Studio.PARAMETER_ID() { data1 = 104037043, data2 = 816272687 };

			public static void SetPauseState(ELabel_PauseState value) => RuntimeManager.StudioSystem.setParameterByID(PauseStateId, (int) value);
			public static ELabel_PauseState GetPauseState()
			{
				RuntimeManager.StudioSystem.getParameterByID(PauseStateId, out var value);
				return (ELabel_PauseState) (int) value;
			}

		}
    
		public static SoundEvent_Game_Pickups_Key Game_Pickups_Key { get; } = new();
		public static SoundEvent_Game_Doors_PropsDoorClose Game_Doors_PropsDoorClose { get; } = new();
		public static SoundEvent_Game_Misc_LukeFirstValveSqueak Game_Misc_LukeFirstValveSqueak { get; } = new();
		public static SoundEvent_Game_Pickups_Glass Game_Pickups_Glass { get; } = new();
		public static SoundEvent_Game_Misc_PuzzleComplete Game_Misc_PuzzleComplete { get; } = new();
		public static SoundEvent_FadeSwitch_LadderBunker FadeSwitch_LadderBunker { get; } = new();
		public static SoundEvent_Music_GramophoneEvent Music_GramophoneEvent { get; } = new();
		public static SoundEvent_Game_Characters_Chehik_ChehikNoise Game_Characters_Chehik_ChehikNoise { get; } = new();
		public static SoundEvent_Game_Characters_PlayerWalkBeton Game_Characters_PlayerWalkBeton { get; } = new();
		public static SoundEvent_UI_Click UI_Click { get; } = new();
		public static SoundEvent_Game_Characters_Chehik_ChehikWalk Game_Characters_Chehik_ChehikWalk { get; } = new();
		public static SoundEvent_Music_BGMBunker Music_BGMBunker { get; } = new();
		public static SoundEvent_Game_BunkerMachins_CupStand Game_BunkerMachins_CupStand { get; } = new();
		public static SoundEvent_Game_Doors_PropsValveOpen Game_Doors_PropsValveOpen { get; } = new();
		public static SoundEvent_Game_BunkerMachins_GlassTap Game_BunkerMachins_GlassTap { get; } = new();
		public static SoundEvent_BunkerEnv_MiceSqueaks BunkerEnv_MiceSqueaks { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerInstall Game_Doors_ChiffanerInstall { get; } = new();
		public static SoundEvent_UI_Hover UI_Hover { get; } = new();
		public static SoundEvent_Game_Misc_LukeSmallUp Game_Misc_LukeSmallUp { get; } = new();
		public static SoundEvent_UI_Achievement UI_Achievement { get; } = new();
		public static SoundEvent_BunkerEnv_WaterColbe BunkerEnv_WaterColbe { get; } = new();
		public static SoundEvent_Game_BunkerMachins_SingleLightTick Game_BunkerMachins_SingleLightTick { get; } = new();
		public static SoundEvent_Game_Misc_LukeUp Game_Misc_LukeUp { get; } = new();
		public static SoundEvent_Game_Misc_Put Game_Misc_Put { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerPickup Game_Doors_ChiffanerPickup { get; } = new();
		public static SoundEvent_Game_Misc_EnvelopeOpen Game_Misc_EnvelopeOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsToiletOpen Game_Doors_PropsToiletOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsBoxOpen Game_Doors_PropsBoxOpen { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerClose Game_Doors_ChiffanerClose { get; } = new();
		public static SoundEvent_FadeSwitch_Onway FadeSwitch_Onway { get; } = new();
		public static SoundEvent_Game_Doors_PropsValveClose Game_Doors_PropsValveClose { get; } = new();
		public static SoundEvent_Game_Doors_PropsSlideOpen Game_Doors_PropsSlideOpen { get; } = new();
		public static SoundEvent_Game_Characters_Chehik_ChehikOutColbe Game_Characters_Chehik_ChehikOutColbe { get; } = new();
		public static SoundEvent_Game_Characters_PlayerWalkGround Game_Characters_PlayerWalkGround { get; } = new();
		public static SoundEvent_Game_BunkerMachins_EmptyPick Game_BunkerMachins_EmptyPick { get; } = new();
		public static SoundEvent_Game_Misc_GrabInventory Game_Misc_GrabInventory { get; } = new();
		public static SoundEvent_Game_Doors_PropsUnlock Game_Doors_PropsUnlock { get; } = new();
		public static SoundEvent_Game_Doors_ClassicLocked Game_Doors_ClassicLocked { get; } = new();
		public static SoundEvent_Game_Doors_PropsLocked Game_Doors_PropsLocked { get; } = new();
		public static SoundEvent_Game_Misc_DropInventory Game_Misc_DropInventory { get; } = new();
		public static SoundEvent_Game_Misc_RoomTone Game_Misc_RoomTone { get; } = new();
		public static SoundEvent_Game_BunkerMachins_ConsoleButtons Game_BunkerMachins_ConsoleButtons { get; } = new();
		public static SoundEvent_Game_Characters_PlayerWalk Game_Characters_PlayerWalk { get; } = new();
		public static SoundEvent_Game_BunkerMachins_ConsoleButtonUp Game_BunkerMachins_ConsoleButtonUp { get; } = new();
		public static SoundEvent_Game_Misc_LukeSecondValveSqueak Game_Misc_LukeSecondValveSqueak { get; } = new();
		public static SoundEvent_Music_Menu Music_Menu { get; } = new();
		public static SoundEvent_Game_Misc_LukeFirstValveImpact Game_Misc_LukeFirstValveImpact { get; } = new();
		public static SoundEvent_Game_BunkerMachins_AcceptConsole Game_BunkerMachins_AcceptConsole { get; } = new();
		public static SoundEvent_Game_Misc_CodeChanged Game_Misc_CodeChanged { get; } = new();
		public static SoundEvent_Game_Doors_PropsSlideClose Game_Doors_PropsSlideClose { get; } = new();
		public static SoundEvent_Game_Doors_FridgeOpen Game_Doors_FridgeOpen { get; } = new();
		public static SoundEvent_Game_Doors_BunkerOpen Game_Doors_BunkerOpen { get; } = new();
		public static SoundEvent_UI_Select UI_Select { get; } = new();
		public static SoundEvent_Game_Doors_PropsDoorOpen Game_Doors_PropsDoorOpen { get; } = new();
		public static SoundEvent_BunkerEnv_RandomBoom BunkerEnv_RandomBoom { get; } = new();
		public static SoundEvent_Game_Pickups_Fuel Game_Pickups_Fuel { get; } = new();
		public static SoundEvent_Game_Misc_ElectroButtonUp Game_Misc_ElectroButtonUp { get; } = new();
		public static SoundEvent_Game_BunkerMachins_DeceinConsole Game_BunkerMachins_DeceinConsole { get; } = new();
		public static SoundEvent_Music_EndBloodline Music_EndBloodline { get; } = new();
		public static SoundEvent_Game_Doors_PropsBoxClose Game_Doors_PropsBoxClose { get; } = new();
		public static SoundEvent_Game_Doors_PropsToiletClose Game_Doors_PropsToiletClose { get; } = new();
		public static SoundEvent_Game_Pickups_Plate Game_Pickups_Plate { get; } = new();
		public static SoundEvent_Game_Misc_ElectroButtonDown Game_Misc_ElectroButtonDown { get; } = new();
		public static SoundEvent_Game_Pickups_Collectable Game_Pickups_Collectable { get; } = new();
		public static SoundEvent_BunkerEnv_Dripping BunkerEnv_Dripping { get; } = new();
		public static SoundEvent_Game_Doors_FridgeClose Game_Doors_FridgeClose { get; } = new();
		public static SoundEvent_Game_Misc_TelevisionButtonDown Game_Misc_TelevisionButtonDown { get; } = new();
		public static SoundEvent_Game_Pickups_Wood Game_Pickups_Wood { get; } = new();
		public static SoundEvent_Game_BunkerMachins_SmallMetalDoor Game_BunkerMachins_SmallMetalDoor { get; } = new();
		public static SoundEvent_Game_Doors_ClassicOpenClose Game_Doors_ClassicOpenClose { get; } = new();
		public static SoundEvent_Game_BunkerMachins_GenDontWork Game_BunkerMachins_GenDontWork { get; } = new();
		public static SoundEvent_Game_Misc_TelevisionScreenTap Game_Misc_TelevisionScreenTap { get; } = new();
		public static SoundEvent_Game_BunkerMachins_GeneratorFill Game_BunkerMachins_GeneratorFill { get; } = new();
		public static SoundEvent_Game_Misc_TelevisionButtonUp Game_Misc_TelevisionButtonUp { get; } = new();
		public static SoundEvent_Music_BGM Music_BGM { get; } = new();
		public static SoundEvent_Game_BunkerMachins_LoadConsole Game_BunkerMachins_LoadConsole { get; } = new();
		public static SoundEvent_Game_Pickups_Paper Game_Pickups_Paper { get; } = new();
		public static SoundEvent_Game_Doors_ClassicUnlock Game_Doors_ClassicUnlock { get; } = new();
		public static SoundEvent_UI_Scroll UI_Scroll { get; } = new();
		public static SoundEvent_Game_BunkerMachins_GeneratorWork Game_BunkerMachins_GeneratorWork { get; } = new();
		public static SoundEvent_BunkerEnv_LightOn BunkerEnv_LightOn { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerOpen Game_Doors_ChiffanerOpen { get; } = new();
		public static SoundEvent_Game_BunkerMachins_ColbaOpen Game_BunkerMachins_ColbaOpen { get; } = new();
    }

	public class SoundEvent_Game_Pickups_Key : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 265;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -143634430, Data2 = 1185644692, Data3 = -1224909409, Data4 = 1828588164 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsDoorClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1000;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1768587003, Data2 = 1136484611, Data3 = 1185273526, Data4 = 1241452680 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_LukeFirstValveSqueak : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1500;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 606607113, Data2 = 1213875972, Data3 = 612115857, Data4 = -1253089790 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Pickups_Glass : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 500;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 134882573, Data2 = 1205054416, Data3 = -537809744, Data4 = -2074779425 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_PuzzleComplete : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 836;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1821818349, Data2 = 1311416463, Data3 = -2139594596, Data4 = 1734662935 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_FadeSwitch_LadderBunker : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 4150;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 477555219, Data2 = 1306748296, Data3 = 1907043988, Data4 = -1272564261 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Music_GramophoneEvent : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 189984;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 675173909, Data2 = 1234133420, Data3 = -2128180844, Data4 = 1905896705 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			private static readonly FMOD.Studio.PARAMETER_ID GramophoneVelocityId = new FMOD.Studio.PARAMETER_ID() { data1 = 2385229767, data2 = 924955554 };

			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

			public void SetGramophoneVelocity(float value) => this.Instance.setParameterByID(GramophoneVelocityId, value);
			public float GetGramophoneVelocity()
			{
				this.Instance.getParameterByID(GramophoneVelocityId, out var value);
				return value;
			}

		}
	}

	public class SoundEvent_Game_Characters_Chehik_ChehikNoise : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 26088;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1729715485, Data2 = 1256357064, Data3 = -731606095, Data4 = -1651336643 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Characters_PlayerWalkBeton : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1360;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1270299617, Data2 = 1248494543, Data3 = -1242980981, Data4 = 597905460 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_UI_Click : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 133;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -653917656, Data2 = 1136402062, Data3 = 1857164724, Data4 = -611272453 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Characters_Chehik_ChehikWalk : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1000;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -572648146, Data2 = 1175104184, Data3 = -1510644310, Data4 = 1304260462 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Music_BGMBunker : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 8300;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 440895534, Data2 = 1106836941, Data3 = -968104016, Data4 = 856815534 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_CupStand : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 460;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -559872203, Data2 = 1229557584, Data3 = -814588759, Data4 = -797240788 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsValveOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 724;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -41830859, Data2 = 1197501045, Data3 = -880787807, Data4 = 377052528 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_GlassTap : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 188;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1053151941, Data2 = 1298969460, Data3 = 2059485367, Data4 = -528956482 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_BunkerEnv_MiceSqueaks : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 5538;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -21221060, Data2 = 1323619490, Data3 = -1404055632, Data4 = -1513255838 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_ChiffanerInstall : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 687;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -829063108, Data2 = 1198634699, Data3 = 43341245, Data4 = 1217387080 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_UI_Hover : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 68;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -957795521, Data2 = 1233169216, Data3 = 2013066115, Data4 = -2077493777 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_LukeSmallUp : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 2000;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1235006272, Data2 = 1111167412, Data3 = -1332513148, Data4 = 185611257 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_UI_Achievement : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 3603;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 417531457, Data2 = 1174842995, Data3 = 12922296, Data4 = -1204432844 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_BunkerEnv_WaterColbe : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 38500;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1956069054, Data2 = 1154360357, Data3 = -1677557851, Data4 = 1184353710 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_SingleLightTick : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 150;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1974165685, Data2 = 1122737157, Data3 = 697393842, Data4 = 1522320439 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_LukeUp : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 3500;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 140957007, Data2 = 1285432180, Data3 = -654629204, Data4 = 104140723 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_Put : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 687;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1655223378, Data2 = 1134739298, Data3 = 1227707525, Data4 = -1814829709 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_ChiffanerPickup : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 250;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1511492524, Data2 = 1210862987, Data3 = 1106791324, Data4 = -624966896 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_EnvelopeOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 3300;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 716425557, Data2 = 1251773731, Data3 = 296599214, Data4 = -951543946 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsToiletOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 580;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 674854230, Data2 = 1203306626, Data3 = -1097385564, Data4 = -1496042369 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsBoxOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 748;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 7067993, Data2 = 1112440040, Data3 = -153636184, Data4 = -1508001311 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_ChiffanerClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 600;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1576939681, Data2 = 1089097459, Data3 = 1590049184, Data4 = 287387383 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_FadeSwitch_Onway : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 5035;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1555112097, Data2 = 1338700720, Data3 = 1790548866, Data4 = -1564342172 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsValveClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 724;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1730536608, Data2 = 1136570188, Data3 = 1023523468, Data4 = 159597420 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsSlideOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1200;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 50907237, Data2 = 1275415385, Data3 = 1501570192, Data4 = -1067354235 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Characters_Chehik_ChehikOutColbe : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 5876;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1974468246, Data2 = 1194979565, Data3 = 425436341, Data4 = -1265540969 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Characters_PlayerWalkGround : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1360;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 726014317, Data2 = 1304226114, Data3 = -25043310, Data4 = -2036955922 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_EmptyPick : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 228;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 295128941, Data2 = 1279834725, Data3 = 2015772048, Data4 = 1313082826 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_GrabInventory : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 532;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -864594576, Data2 = 1284085227, Data3 = 880672160, Data4 = -1526129930 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsUnlock : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 350;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1143554161, Data2 = 1262240233, Data3 = -524453745, Data4 = 420849189 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_ClassicLocked : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 616;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1730481780, Data2 = 1212147640, Data3 = 1701157822, Data4 = 871384296 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsLocked : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 616;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 889358201, Data2 = 1168042271, Data3 = -545674611, Data4 = -1159365732 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_DropInventory : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 403;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -170419075, Data2 = 1140003302, Data3 = -1628494947, Data4 = -1718260067 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_RoomTone : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 123845;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1572736127, Data2 = 1329593092, Data3 = 1852688798, Data4 = -1938217271 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_ConsoleButtons : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 186;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -100853888, Data2 = 1327943287, Data3 = 1846832272, Data4 = 589312547 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Characters_PlayerWalk : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1384;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1472852616, Data2 = 1221819984, Data3 = -1346469502, Data4 = 681418791 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_ConsoleButtonUp : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 12;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -640166766, Data2 = 1181741141, Data3 = -1093318733, Data4 = -1358836183 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_LukeSecondValveSqueak : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1010;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1835721836, Data2 = 1326425696, Data3 = 379066500, Data4 = 1330215492 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Music_Menu : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 191331;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1247552362, Data2 = 1227610015, Data3 = -1166220665, Data4 = 1664410332 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_LukeFirstValveImpact : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1600;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1865030040, Data2 = 1123165569, Data3 = 1933804684, Data4 = 688141254 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_AcceptConsole : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 900;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -358078049, Data2 = 1283400929, Data3 = -1537185144, Data4 = 92721903 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_CodeChanged : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 234;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 242043557, Data2 = 1193425016, Data3 = 1636394371, Data4 = 1915944667 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsSlideClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1200;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1101502041, Data2 = 1085210910, Data3 = -296707178, Data4 = 445664429 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_FridgeOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1000;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -237460048, Data2 = 1304599288, Data3 = 1257570210, Data4 = 522449072 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_BunkerOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 4500;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -517713995, Data2 = 1083553432, Data3 = -666863430, Data4 = 1310010374 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_UI_Select : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 85;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1762932299, Data2 = 1150821187, Data3 = 710381722, Data4 = 49048003 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsDoorOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 580;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1840847035, Data2 = 1324107018, Data3 = -1657627509, Data4 = -26384651 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_BunkerEnv_RandomBoom : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 6800;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 269895356, Data2 = 1265007420, Data3 = 830902157, Data4 = -1448921396 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Pickups_Fuel : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1400;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -449827902, Data2 = 1158834923, Data3 = 1023794825, Data4 = 776699372 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_ElectroButtonUp : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 358;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1753637688, Data2 = 1292968725, Data3 = 811670168, Data4 = -1817928684 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_DeceinConsole : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 290;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 2002640840, Data2 = 1341472770, Data3 = 1821091767, Data4 = -659860605 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Music_EndBloodline : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 190000;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -956501811, Data2 = 1230830454, Data3 = -1172329816, Data4 = 910972460 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsBoxClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 500;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1040061648, Data2 = 1196539138, Data3 = -1525016693, Data4 = 838440114 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_PropsToiletClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 500;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 2116622549, Data2 = 1169773332, Data3 = -2092198238, Data4 = -1697628845 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Pickups_Plate : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 465;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1680753191, Data2 = 1268123024, Data3 = -687526497, Data4 = -1073329918 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_ElectroButtonDown : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 408;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -2089235751, Data2 = 1268413989, Data3 = 288921494, Data4 = -1670464828 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Pickups_Collectable : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 750;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 553993693, Data2 = 1267126535, Data3 = 665609372, Data4 = -1906483769 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_BunkerEnv_Dripping : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 7080;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1075435997, Data2 = 1290949446, Data3 = -1961783893, Data4 = 1082511880 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_FridgeClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1000;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1502912802, Data2 = 1201617741, Data3 = 313266087, Data4 = -816119672 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_TelevisionButtonDown : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 408;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1708889312, Data2 = 1216226098, Data3 = -1409180510, Data4 = -1572259441 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Pickups_Wood : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 200;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -947825183, Data2 = 1195424432, Data3 = 438572930, Data4 = -721581957 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_SmallMetalDoor : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 400;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1361403873, Data2 = 1082685760, Data3 = -1809246041, Data4 = 335046762 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_ClassicOpenClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1440;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -869096729, Data2 = 1284696489, Data3 = 1881439620, Data4 = -853788377 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_GenDontWork : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 4050;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1376489704, Data2 = 1143189045, Data3 = -434163838, Data4 = 1157284953 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_TelevisionScreenTap : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 519;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1659361513, Data2 = 1236654733, Data3 = 1171113379, Data4 = -1924035318 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_GeneratorFill : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 3528;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -424867094, Data2 = 1331463220, Data3 = 1033658298, Data4 = -710419120 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Misc_TelevisionButtonUp : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 358;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 196489450, Data2 = 1123648569, Data3 = -359836997, Data4 = -898235784 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Music_BGM : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 154853;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1844844822, Data2 = 1164680780, Data3 = 432059048, Data4 = 1817123738 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_LoadConsole : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 682;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -790157844, Data2 = 1076498148, Data3 = 1325982350, Data4 = -770807057 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Pickups_Paper : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 330;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1641164780, Data2 = 1267320035, Data3 = -219452775, Data4 = 35285274 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_ClassicUnlock : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1547;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1898611439, Data2 = 1097014406, Data3 = 537778085, Data4 = 21287164 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_UI_Scroll : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 52;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 2016224761, Data2 = 1335053742, Data3 = 1643764617, Data4 = -365945755 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_GeneratorWork : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 171800;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -339919367, Data2 = 1227945739, Data3 = 632333716, Data4 = 1842716565 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_BunkerEnv_LightOn : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 3000;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 2105353724, Data2 = 1302731917, Data3 = -1829109094, Data4 = 1688435856 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_Doors_ChiffanerOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 600;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 44454908, Data2 = 1216834629, Data3 = -2018856783, Data4 = -229859209 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

	public class SoundEvent_Game_BunkerMachins_ColbaOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1802;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = 1263474942, Data2 = 1229480257, Data3 = 593775292, Data4 = -29095648 };

		public void PlayOneShot() => RuntimeManager.PlayOneShot(_guid);
		public void PlayOneShotAttached(GameObject attachTo) => RuntimeManager.PlayOneShotAttached(_guid, attachTo);
		public void PlayOneShotInPoint(Vector3 point) => RuntimeManager.PlayOneShot(_guid, point);

		public Instance CreateInstance() => new Instance(RuntimeManager.CreateInstance(_guid));
		ISoundEventInstance ISoundEvent.CreateInstance() => CreateInstance();

		public class Instance : SoundEventInstance
		{
			public Instance(FMOD.Studio.EventInstance eventInstance) : base(eventInstance) { }

		}
	}

}