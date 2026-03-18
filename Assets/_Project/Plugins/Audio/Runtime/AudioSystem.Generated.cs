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
		public static SoundEvent_Game_PickupItem Game_PickupItem { get; } = new();
		public static SoundEvent_Music_BGMBunker Music_BGMBunker { get; } = new();
		public static SoundEvent_UI_Hover UI_Hover { get; } = new();
		public static SoundEvent_UI_Achievement UI_Achievement { get; } = new();
		public static SoundEvent_Game_SwipeItem Game_SwipeItem { get; } = new();
		public static SoundEvent_Game_GrabInventory Game_GrabInventory { get; } = new();
		public static SoundEvent_Game_DropInventory Game_DropInventory { get; } = new();
		public static SoundEvent_Game_Walk Game_Walk { get; } = new();
		public static SoundEvent_Music_Menu Music_Menu { get; } = new();
		public static SoundEvent_UI_Select UI_Select { get; } = new();
		public static SoundEvent_Music_BGM Music_BGM { get; } = new();
		public static SoundEvent_UI_Scroll UI_Scroll { get; } = new();
		public static SoundEvent_Game_Door_Closed Game_Door_Closed { get; } = new();
		public static SoundEvent_Game_Door_Unlock Game_Door_Unlock { get; } = new();
		public static SoundEvent_Game_Door_OpenClose Game_Door_OpenClose { get; } = new();
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

	public class SoundEvent_Game_PickupItem : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1162;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1574593495, Data2 = 1196419271, Data3 = 580173476, Data4 = -783740866 };

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

	public class SoundEvent_Game_SwipeItem : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1645;

		private static readonly FMOD.GUID _guid = new FMOD.GUID() { Data1 = -1693067954, Data2 = 1116941065, Data3 = 629675189, Data4 = -508412772 };

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

	public class SoundEvent_Game_GrabInventory : ISoundEvent
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

	public class SoundEvent_Game_DropInventory : ISoundEvent
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

	public class SoundEvent_Game_Walk : ISoundEvent
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

	public class SoundEvent_Game_Door_Closed : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 0;

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

	public class SoundEvent_Game_Door_Unlock : ISoundEvent
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

	public class SoundEvent_Game_Door_OpenClose : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 1890;

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

}