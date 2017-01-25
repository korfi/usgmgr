using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.Background;

namespace USG_tablet_UI
{
    public class BeaconTestHandler
    {
        public BeaconTestHandler()
        {
            BluetoothLEAdvertisementWatcher watcher = new BluetoothLEAdvertisementWatcher();
            watcher.Received += OnAdvertisementReceived;
            watcher.Start();
        }

        private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
        {
            GlobalSettings.beaconDistance = Convert.ToString(eventArgs.RawSignalStrengthInDBm);
        }
    }

}
