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
    
		public static SoundEvent_UI_Click UI_Click { get; } = new();
		public static SoundEvent_UI_Hover UI_Hover { get; } = new();
		public static SoundEvent_UI_Scroll UI_Scroll { get; } = new();
		public static SoundEvent_Game_Pickups_Key Game_Pickups_Key { get; } = new();
		public static SoundEvent_Game_Misc_PuzzleComplete Game_Misc_PuzzleComplete { get; } = new();
		public static SoundEvent_Music_BGMBunker Music_BGMBunker { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerInstall Game_Doors_ChiffanerInstall { get; } = new();
		public static SoundEvent_UI_Achievement UI_Achievement { get; } = new();
		public static SoundEvent_Game_Misc_Put Game_Misc_Put { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerPickup Game_Doors_ChiffanerPickup { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerClose Game_Doors_ChiffanerClose { get; } = new();
		public static SoundEvent_Game_Misc_GrabInventory Game_Misc_GrabInventory { get; } = new();
		public static SoundEvent_Game_Doors_ClassicLocked Game_Doors_ClassicLocked { get; } = new();
		public static SoundEvent_Game_Misc_DropInventory Game_Misc_DropInventory { get; } = new();
		public static SoundEvent_Game_Characters_PlayerWalk Game_Characters_PlayerWalk { get; } = new();
		public static SoundEvent_Music_Menu Music_Menu { get; } = new();
		public static SoundEvent_Game_Doors_BunkerOpen Game_Doors_BunkerOpen { get; } = new();
		public static SoundEvent_UI_Select UI_Select { get; } = new();
		public static SoundEvent_Game_Pickups_Wood Game_Pickups_Wood { get; } = new();
		public static SoundEvent_Game_Doors_ClassicOpenClose Game_Doors_ClassicOpenClose { get; } = new();
		public static SoundEvent_Music_BGM Music_BGM { get; } = new();
		public static SoundEvent_Game_Pickups_Paper Game_Pickups_Paper { get; } = new();
		public static SoundEvent_Game_Doors_ClassicUnlock Game_Doors_ClassicUnlock { get; } = new();
		public static SoundEvent_Game_Doors_ChiffanerOpen Game_Doors_ChiffanerOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsDoorClose Game_Doors_PropsDoorClose { get; } = new();
		public static SoundEvent_Game_Doors_PropsBoxOpen Game_Doors_PropsBoxOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsSlideOpen Game_Doors_PropsSlideOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsUnlock Game_Doors_PropsUnlock { get; } = new();
		public static SoundEvent_Game_Doors_PropsLocked Game_Doors_PropsLocked { get; } = new();
		public static SoundEvent_Game_Doors_PropsSlideClose Game_Doors_PropsSlideClose { get; } = new();
		public static SoundEvent_Game_Doors_FridgeOpen Game_Doors_FridgeOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsDoorOpen Game_Doors_PropsDoorOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsBoxClose Game_Doors_PropsBoxClose { get; } = new();
		public static SoundEvent_Game_Doors_FridgeClose Game_Doors_FridgeClose { get; } = new();
		public static SoundEvent_Game_Pickups_Plate Game_Pickups_Plate { get; } = new();
		public static SoundEvent_Game_Doors_PropsValveOpen Game_Doors_PropsValveOpen { get; } = new();
		public static SoundEvent_Game_Doors_PropsValveClose Game_Doors_PropsValveClose { get; } = new();
		public static SoundEvent_Game_Misc_CodeChanged Game_Misc_CodeChanged { get; } = new();
		public static SoundEvent_Game_Misc_ElectroButtonUp Game_Misc_ElectroButtonUp { get; } = new();
		public static SoundEvent_Game_Misc_ElectroButtonDown Game_Misc_ElectroButtonDown { get; } = new();
		public static SoundEvent_Game_Misc_TelevisionButtonDown Game_Misc_TelevisionButtonDown { get; } = new();
		public static SoundEvent_Game_Misc_TelevisionScreenTap Game_Misc_TelevisionScreenTap { get; } = new();
		public static SoundEvent_Game_Misc_TelevisionButtonUp Game_Misc_TelevisionButtonUp { get; } = new();
		public static SoundEvent_Game_Misc_LukeFirstValveSqueak Game_Misc_LukeFirstValveSqueak { get; } = new();
		public static SoundEvent_Game_Misc_LukeSmallUp Game_Misc_LukeSmallUp { get; } = new();
		public static SoundEvent_Game_Misc_LukeUp Game_Misc_LukeUp { get; } = new();
		public static SoundEvent_Game_Misc_RoomTone Game_Misc_RoomTone { get; } = new();
		public static SoundEvent_Game_Misc_LukeSecondValveSqueak Game_Misc_LukeSecondValveSqueak { get; } = new();
		public static SoundEvent_Game_Misc_LukeFirstValveImpact Game_Misc_LukeFirstValveImpact { get; } = new();
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

	public class SoundEvent_Music_BGMBunker : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 64062;

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

	public class SoundEvent_Music_Menu : ISoundEvent
	{
		public bool IsOneShot => false;
		public float Length => 351384;

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

	public class SoundEvent_Game_Doors_BunkerOpen : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1500;

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

	public class SoundEvent_Game_Pickups_Plate : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 200;

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

	public class SoundEvent_Game_Misc_LukeSecondValveSqueak : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1237;

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

}