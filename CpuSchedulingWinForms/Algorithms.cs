using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {
        public static void fcfsAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int npX2 = np * 2;

            double[] bp = new double[np];
            double[] wtp = new double[np];
            string[] output1 = new string[npX2];
            double twt = 0.0, awt; 
            int num;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    //MessageBox.Show("Enter Burst time for P" + (num + 1) + ":", "Burst time for Process", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //Console.WriteLine("\nEnter Burst time for P" + (num + 1) + ":");

                    string input =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ",
                                                       "Burst time for P" + (num + 1),
                                                       "",
                                                       -1, -1);

                    bp[num] = Convert.ToInt64(input);

                    //var input = Console.ReadLine();
                    //bp[num] = Convert.ToInt32(input);
                }

                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        wtp[num] = 0;
                    }
                    else
                    {
                        wtp[num] = wtp[num - 1] + bp[num - 1];
                        MessageBox.Show("Waiting time for P" + (num + 1) + " = " + wtp[num], "Job Queue", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                awt = twt / np;
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + awt + " sec(s)", "Average Awaiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (result == DialogResult.No)
            {
                //this.Hide();
                //Form1 frm = new Form1();
                //frm.ShowDialog();
            }
        }

        public static void sjfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] bp = new double[np];
            double[] wtp = new double[np];
            double[] p = new double[np];
            double twt = 0.0, awt; 
            int x, num;
            double temp = 0.0;
            bool found = false;

            DialogResult result = MessageBox.Show("Shortest Job First Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    p[num] = bp[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (p[num] > p[num + 1])
                        {
                            temp = p[num];
                            p[num] = p[num + 1];
                            p[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time:", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + p[num - 1];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void priorityAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            DialogResult result = MessageBox.Show("Priority Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] bp = new double[np];
                double[] wtp = new double[np + 1];
                int[] p = new int[np];
                int[] sp = new int[np];
                int x, num;
                double twt = 0.0;
                double awt;
                int temp = 0;
                bool found = false;
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    string input2 =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter priority: ",
                                                           "Priority for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    p[num] = Convert.ToInt16(input2);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    sp[num] = p[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (sp[num] > sp[num + 1])
                        {
                            temp = sp[num];
                            sp[num] = sp[num + 1];
                            sp[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + bp[temp];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Console.WriteLine("\n\nAverage waiting time: " + (awt = twt / np));
                //Console.ReadLine();
            }
            else
            {
                //this.Hide();
            }
        }

        public static void roundRobinAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int i, counter = 0;
            double total = 0.0;
            double timeQuantum;
            double waitTime = 0, turnaroundTime = 0;
            double averageWaitTime, averageTurnaroundTime;
            double[] arrivalTime = new double[10];
            double[] burstTime = new double[10];
            double[] temp = new double[10];
            int x = np;

            DialogResult result = MessageBox.Show("Round Robin Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < np; i++)
                {
                    string arrivalInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    arrivalTime[i] = Convert.ToInt64(arrivalInput);

                    string burstInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    burstTime[i] = Convert.ToInt64(burstInput);

                    temp[i] = burstTime[i];
                }
                string timeQuantumInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum: ", "Time Quantum",
                                                               "",
                                                               -1, -1);

                timeQuantum = Convert.ToInt64(timeQuantumInput);
                Helper.QuantumTime = timeQuantumInput;

                for (total = 0, i = 0; x != 0;)
                {
                    if (temp[i] <= timeQuantum && temp[i] > 0)
                    {
                        total = total + temp[i];
                        temp[i] = 0;
                        counter = 1;
                    }
                    else if (temp[i] > 0)
                    {
                        temp[i] = temp[i] - timeQuantum;
                        total = total + timeQuantum;
                    }
                    if (temp[i] == 0 && counter == 1)
                    {
                        x--;
                        //printf("nProcess[%d]tt%dtt %dttt %d", i + 1, burst_time[i], total - arrival_time[i], total - arrival_time[i] - burst_time[i]);
                        MessageBox.Show("Turnaround time for Process " + (i + 1) + " : " + (total - arrivalTime[i]), "Turnaround time for Process " + (i + 1), MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + (i + 1) + " : " + (total - arrivalTime[i] - burstTime[i]), "Wait time for Process " + (i + 1), MessageBoxButtons.OK);
                        turnaroundTime = (turnaroundTime + total - arrivalTime[i]);
                        waitTime = (waitTime + total - arrivalTime[i] - burstTime[i]);                        
                        counter = 0;
                    }
                    if (i == np - 1)
                    {
                        i = 0;
                    }
                    else if (arrivalTime[i + 1] <= total)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                averageWaitTime = Convert.ToInt64(waitTime * 1.0 / np);
                averageTurnaroundTime = Convert.ToInt64(turnaroundTime * 1.0 / np);
                MessageBox.Show("Average wait time for " + np + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + np + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
            }
        }
        //Shortest Remaining Time First Scheduling goes here
        public static List<ProcessResult> srtfAlgorithm(string userInput)
        {
            List<ProcessResult> results = new List<ProcessResult>();

            int np = Convert.ToInt16(userInput);
            int[] arrivalTime = new int[np];
            int[] burstTime = new int[np];
            int[] remainingTime = new int[np];
            int[] predictedTime = new int[np];
            int[] completionTime = new int[np];
            int[] turnaroundTime = new int[np];
            int[] waitingTime = new int[np];
            bool[] isCompleted = new bool[np];
            int averageWaitTime = 0;
            int averageTurnaroundTime = 0;
            int currentTime = 0;
            int completed = 0;
            int totalBurstTime = 0;
            double cpuUtilization = 0;
            double throughput = 0;

            Random rnd = new Random();

            DialogResult result = MessageBox.Show("Shortest Remaining Time First", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    /**
                    string arrivalInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (i + 1),
                                                               "",
                                                               -1, -1);
                    */
                    //arrivalTime[i] = (int)Convert.ToInt64(arrivalInput);
                    arrivalTime[i] = rnd.Next(0, 30);

                    /**
                    string burstInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (i + 1),
                                                               "",
                                                               -1, -1);
                    */
                    //burstTime[i] = (int)Convert.ToInt64(burstInput);
                    burstTime[i] = rnd.Next(1, 30);

                    remainingTime[i] = burstTime[i];

                    /**
                    string predictedInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter predicted time: ",
                                                               "Predicted time for P" + (i + 1),
                                                               "",
                                                               -1, -1);
                    */
                    //predictedTime[i] = (int)Convert.ToInt64(predictedInput);
                    predictedTime[i] = rnd.Next(1, 30);

                }

                while (completed != np)
                {
                    int shortest = -1;
                    for (int i = 0; i < np; i++)
                    {
                        if (!isCompleted[i] && arrivalTime[i] <= currentTime)
                        {
                            if (shortest == -1 || remainingTime[i] < remainingTime[shortest])
                            {
                                shortest = i;
                            }
                        }
                    }
                    if (shortest == -1)
                    {
                        currentTime++;
                        continue;
                    }
                    remainingTime[shortest]--;

                    if (remainingTime[shortest] == 0)
                    {
                        completionTime[shortest] = currentTime + 1;
                        turnaroundTime[shortest] = Math.Max(completionTime[shortest] - arrivalTime[shortest], 0);
                        waitingTime[shortest] = Math.Max(turnaroundTime[shortest] - burstTime[shortest], 0);
                        isCompleted[shortest] = true;
                        completed++;
                    }
                    currentTime++;
                }
                for (int i = 0; i < np; i++)
                {
                    results.Add(new ProcessResult
                    {
                        ProcessID = "P" + (i+1),
                        AT = arrivalTime[i],
                        BT = burstTime[i],
                        CT = completionTime[i],
                        TT = turnaroundTime[i],
                        WT = waitingTime[i],
                        PT = predictedTime[i]
                    }) ;
                    //MessageBox.Show("Wait time for Process " + (i + 1) + " : " + (waitingTime[i]), "Wait time for Process " + (i + 1), MessageBoxButtons.OK);
                    //MessageBox.Show("Turnaround time for Process " + (i + 1) + " : " + (turnaroundTime[i]), "Turnaround time for Process " + (i + 1), MessageBoxButtons.OK);
                }

                for (int i = 0; i < np; i++)
                {
                    averageWaitTime += waitingTime[i];
                    averageTurnaroundTime += turnaroundTime[i];
                    totalBurstTime += burstTime[i];
                }
                averageWaitTime = (int)Convert.ToInt32(averageWaitTime * 1.0 / np);
                averageTurnaroundTime = (int)Convert.ToInt32(averageTurnaroundTime / np);
                MessageBox.Show("Average wait time for " + np + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + np + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
                if (currentTime > 0)
                {
                    cpuUtilization = (double)totalBurstTime / currentTime * 100;
                    throughput = (double)np / currentTime;
                }
                MessageBox.Show($"CPU Utilization: {cpuUtilization.ToString("0.00")}%",
                       "CPU Utilization", MessageBoxButtons.OK);
                
                MessageBox.Show($"Throughput: {throughput.ToString("0.00")} processes per time unit",
                               "Throughput", MessageBoxButtons.OK);
            }
            return results;

        }

        ///New Algorithm Here
        public static List<ProcessResult> hrrnAlgorithm(string userInput)
        {
            List<ProcessResult> results = new List<ProcessResult>();
            int np = Convert.ToInt16(userInput);
            int currentTime = 0;
            int completedProcesses = 0;
            int totalBurstTime = 0;
            double cpuUtilization = 0;
            double totalWaitingTime = 0;
            double totalTurnAroundTime = 0;
            double throughput = 0;
            Random rnd = new Random();
            DialogResult result = MessageBox.Show("The Highest Response Ratio Next", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                var processes = new List<int[]>();

                for (int i = 0; i < np; i++)
                {
                    
                    int arrivalTime = rnd.Next(0, 30);
                    /**string arrivalInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (i + 1),
                                                               "",
                                                               -1, -1);
                    */

                    //int arrivalTime = (int)Convert.ToInt64(arrivalInput);

                    /**string burstInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (i + 1),
                                                               "",
                                                               -1, -1);
                    */
                    int burstTime = rnd.Next(0, 30);
                    //int burstTime = (int)Convert.ToInt64(burstInput);

                    processes.Add(new int[] { i + 1, arrivalTime, burstTime, 0, 0 });
                }
                while (completedProcesses < np)
                {
                    double maxRR = -1;
                    int selectedIndex = -1;

                    for (int i = 0; i < processes.Count; i++)
                    {
                        var p = processes[i];
                        if (p[4] == 1 || p[1] > currentTime)
                        {
                            continue;
                        }
                        int waitingTime = currentTime - p[1];
                        double rRatio = (double) (waitingTime + p[2]) / p[2];
                        if (rRatio > maxRR)
                        {
                            maxRR = rRatio;
                            selectedIndex = i;
                        }

                    }
                    if (selectedIndex == -1)
                    {
                        currentTime++;
                        continue;
                    }
                    var selected = processes[selectedIndex];
                    currentTime += selected[2];
                    selected[3] = currentTime;
                    selected[4] = 1;
                    completedProcesses++;
                }

                foreach (var p in processes.OrderBy(p => p[0]))
                {
                    int turnaroundTime = p[3] - p[1];
                    int waitTime = turnaroundTime - p[2];
                    double rr = (double)(waitTime + p[2]) / p[2];
                    totalWaitingTime += waitTime;
                    totalTurnAroundTime += turnaroundTime;
                    totalBurstTime += p[2];

                    results.Add(new ProcessResult
                    {
                        ProcessID = "P" + p[0],
                        AT = p[1],
                        BT = p[2],
                        CT = p[3],
                        TT = turnaroundTime,
                        WT = waitTime,
                        RR = Math.Round(rr, 2)
                    });

                    //MessageBox.Show("Wait time for Process " + (p[0]) + " : " + (waitTime), "Wait time for Process " + (p[0]), MessageBoxButtons.OK);
                    //MessageBox.Show("Turnaround time for Process " + (p[0]) + " : " + (turnaroundTime), "Turnaround time for Process " + (p[0]), MessageBoxButtons.OK);
                }
                MessageBox.Show("Average wait time for " + np + " processes: " + (totalWaitingTime / np) + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + np + " processes: " + (totalTurnAroundTime / np) + " sec(s)", "", MessageBoxButtons.OK);
                if (currentTime > 0)
                {
                    cpuUtilization = (double)totalBurstTime / currentTime * 100;
                    throughput = (double)np / currentTime;
                }
                MessageBox.Show($"CPU Utilization: {cpuUtilization.ToString("0.00")}%",
                       "CPU Utilization", MessageBoxButtons.OK);

                MessageBox.Show($"Throughput: {throughput.ToString("0.00")} processes per time unit",
                               "Throughput", MessageBoxButtons.OK);

            }
            return results;
        }
    }
}

