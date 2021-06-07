using System;
using System.Text;

namespace AbstractFactoryDesignPattern
{
    class Program
    {
        interface IKernal
        {
            public void StartOperatingSystem();
        }

        class IosKernal : IKernal
        {
            public void StartOperatingSystem()
            {
                Console.WriteLine("iOS Operating System has been started successfully");
            }
        }

        class WindowsKernal : IKernal
        {
            public void StartOperatingSystem()
            {
                Console.WriteLine("Windows Operating System has been started successfully");
            }
        }

        interface IProcessManager
        {
            public void ShowRunningProcesses();
        }
        class IosProcessManager : IProcessManager
        {
            public void ShowRunningProcesses()
            {
                Console.WriteLine("Running processes in the iOS OS are [process1, process2, process3]");
            }
        }
        class WindowsProcessManager : IProcessManager
        {
            public void ShowRunningProcesses()
            {
                Console.WriteLine("Running processes in the Windows OS are [process1, process2, process3]");
            }
        }
        interface IOperatingSystemFactory
        {
            public IKernal MakeKernal();
            public IProcessManager MakeProcessManager();
        }

        class IosOperatingSystemFactory : IOperatingSystemFactory
        {
            public IKernal MakeKernal()
            {
                return new IosKernal();
            }
            public IProcessManager MakeProcessManager()
            {
                return new IosProcessManager();
            }
        }

        class WindowsOperatingSystemFactory : IOperatingSystemFactory
        {
            public IKernal MakeKernal()
            {
                return new WindowsKernal();
            }
            public IProcessManager MakeProcessManager()
            {
                return new WindowsProcessManager();
            }
        }

        static void Main(string[] args)
        {
            IOperatingSystemFactory osFactory;

            // iOS
            osFactory = new IosOperatingSystemFactory();
            var iOSKernal = osFactory.MakeKernal();
            var iOSProcessManager = osFactory.MakeProcessManager();
            iOSKernal.StartOperatingSystem();
            iOSProcessManager.ShowRunningProcesses();

            Console.WriteLine();

            // Windows
            osFactory = new WindowsOperatingSystemFactory();
            var windowsKernal = osFactory.MakeKernal();
            var windowsProcessManager = osFactory.MakeProcessManager();
            windowsKernal.StartOperatingSystem();
            windowsProcessManager.ShowRunningProcesses();
        }
    }
}
