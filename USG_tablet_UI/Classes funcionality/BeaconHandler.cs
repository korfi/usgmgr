using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.Background;

namespace USG_tablet_UI
{
    public class BeaconHandler
    {

        BluetoothLEAdvertisementWatcher watcher;
        bool triggered = false;
        int i = 0;

        public BeaconHandler()
        {
            watcher = new BluetoothLEAdvertisementWatcher();
            watcher.Received += OnAdvertisementReceived;
            watcher.Start();
        }

        private void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
        {
            /*if (triggered == false)
            {
                GlobalSettings.beaconWindow.Dispatcher.Invoke((Action)delegate { GlobalSettings.beaconWindow.Show(); });
                triggered = true;
            }  */
            GlobalSettings.beaconDistance = i;
            i++;
        }
    }

}
