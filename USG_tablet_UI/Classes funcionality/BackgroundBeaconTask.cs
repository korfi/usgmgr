using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Bluetooth.Background;
using Windows.Devices.Bluetooth.Advertisement;

namespace USG_tablet_UI.Classes_funcionality
{
    public class BackgroundBeaconTask : IBackgroundTask
    {
        private IBackgroundTaskInstance backgroundTaskInstance;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            backgroundTaskInstance = taskInstance;

            var details = taskInstance.TriggerDetails as BluetoothLEAdvertisementWatcherTriggerDetails;

            if (details != null)
            {
                IReadOnlyList<BluetoothLEAdvertisementReceivedEventArgs> advertisements = details.Advertisements;
                foreach (var eventArgs in advertisements)
                {
                    GlobalSettings.beaconDistance = Convert.ToString(eventArgs.RawSignalStrengthInDBm);
                }
            }
        }
        
    }
}
