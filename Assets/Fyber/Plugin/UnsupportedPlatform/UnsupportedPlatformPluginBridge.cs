using UnityEngine;

namespace FyberPlugin
{
#if UNITY_EDITOR
    internal class PluginBridgeComponent : IPluginBridge
	{

		public void StartSDK(string json)
		{
			Debug.Log("Version - " + Application.unityVersion);
			Utils.printWarningMessage();
		}

        public void Cache(string action)	
		{	
			Utils.printWarningMessage();
		}
		
		public void Request(string json)
		{
			Utils.printWarningMessage();
		}
		
		public void StartAd(string json)
		{
			Utils.printWarningMessage();
		}
		
		public void Report(string json)	
		{	
			Utils.printWarningMessage();
		}
		
		public void Settings(string json)
		{
			Utils.printWarningMessage();
        }

        public void EnableLogging(bool shouldLog)
        {
            Utils.printWarningMessage();
		}

    }
#endif
}