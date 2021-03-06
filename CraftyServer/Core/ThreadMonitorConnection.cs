using java.lang;

namespace CraftyServer.Core
{
    public class ThreadMonitorConnection : Thread
    {
        private readonly NetworkManager netManager; /* synthetic field */

        public ThreadMonitorConnection(NetworkManager networkmanager)
        {
            netManager = networkmanager;
//        
        }

        public override void run()
        {
            try
            {
                sleep(2000L);
                if (NetworkManager.isRunning(netManager))
                {
                    NetworkManager.getWriteThread(netManager).interrupt();
                    netManager.networkShutdown("disconnect.closed", new object[0]);
                }
            }
            catch (Exception exception)
            {
                exception.printStackTrace();
            }
        }
    }
}