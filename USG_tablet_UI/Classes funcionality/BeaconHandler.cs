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
    class BeaconHandler
    {

        private IBackgroundTaskRegistration taskRegistration;
        private BluetoothLEAdvertisementWatcherTrigger trigger;
        private string taskName = "backgroundBeaconTask";
        private string taskEntryPoint = "USG_tablet_UI.Classes_funcionality.BackgroundBeaconTask";

        public BeaconHandler()
        {
            trigger = new BluetoothLEAdvertisementWatcherTrigger();
            trigger.SignalStrengthFilter.InRangeThresholdInDBm = -70;
            trigger.SignalStrengthFilter.OutOfRangeThresholdInDBm = -75;
            trigger.SignalStrengthFilter.OutOfRangeTimeout = TimeSpan.FromMilliseconds(2000);
            trigger.SignalStrengthFilter.SamplingInterval = TimeSpan.FromMilliseconds(1000);
                }

        public async void startListening() {
            if (taskRegistration == null)
            {
                BackgroundAccessStatus backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
                var builder = new BackgroundTaskBuilder();
                builder.TaskEntryPoint = taskEntryPoint;
                builder.SetTrigger(trigger);
                builder.Name = taskName;

                try
                {
                    taskRegistration = builder.Register();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async void stopListening()
        {
            if (taskRegistration != null)
            {
                taskRegistration.Unregister(true);
                taskRegistration = null;
            }
        }
    }
}