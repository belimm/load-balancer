using System;
using System.Threading;



namespace LoadBalancer
{
    class LoadBalancer
    {
        static void Main()
        {
            LoadBalancer.Run();
        }

        static void Run(string hostName="localhost",string userName="postgres",string password="2365",string database="havuzarac")
        {
                while(true)
                {
                    
                    var cs = "Host="+hostName+";Username="+userName+";Password="+password+";Database="+database;
                    
                    System.Console.WriteLine("DB Status:"+SqlConnectionHealthCheck.ConnectDB("PostgreSQL",cs));


                    try
                    {
                       
                       
                        
                        var cpuStat = CpuHealthCheck.DoHealthCheck();
                        System.Console.WriteLine("CPU Percentage:" + cpuStat.LoadPercentage + " Health:" + cpuStat.Health);

                        var memoryStat = MemoryMetricsClient.MemoryHealthCheck();
                        System.Console.WriteLine("Memory Percentage:" + memoryStat.LoadPercentage + " Health:" + memoryStat.Health);
                        
                        DiscMetrics.DiscUsagePercentage();



                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.ToString());
                    }

                    Thread.Sleep(10000);
                }
                
         }
        

            
    }
}
