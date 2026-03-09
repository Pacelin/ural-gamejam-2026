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
		}
    
		public static SoundEvent_UI_Click UI_Click { get; } = new();
		public static SoundEvent_UI_Scroll UI_Scroll { get; } = new();
		public static SoundEvent_UI_Hover UI_Hover { get; } = new();
    }

	public class SoundEvent_UI_Click : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 36;

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

	public class SoundEvent_UI_Hover : ISoundEvent
	{
		public bool IsOneShot => true;
		public float Length => 500;

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

}