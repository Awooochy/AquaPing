using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;

class Program {
    static void Main(string[] args) {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;

        Console.WriteLine("            ██████                                              ██████████              ");
        Console.WriteLine("        ████      ████                                      ████          ████          ");
        Console.WriteLine("      ▓▓              ██▓▓                                ██░░░░▒▒██          ██        ");
        Console.WriteLine("    ▓▓                    ████                          ▓▓  ░░▒▒▒▒██          ░░██      ");
        Console.WriteLine("    ██              ░░████    ▓▓                      ██  ░░▒▒▒▒▒▒▒▒██          ░░██    ");
        Console.WriteLine("    ██            ░░██▒▒▒▒▒▒░░  ██                    ██  ▒▒▒▒▒▒▒▒▒▒██          ░░██    ");
        Console.WriteLine("  ██            ░░██▒▒▒▒▒▒▒▒▒▒░░  ██                ██  ░░▒▒▒▒▒▒▒▒░░░░██░░      ░░░░██  ");
        Console.WriteLine("  ██          ░░██░░░░▒▒▒▒▒▒▒▒▒▒░░  ██              ██  ▒▒▒▒▒▒▒▒░░░░██  ██░░░░░░░░░░██  ");
        Console.WriteLine("  ██          ░░██▓▓██░░░░░░▒▒▒▒▒▒░░██            ██░░░░▒▒▒▒▒▒░░░░██      ██░░░░░░░░██  ");
        Console.WriteLine("  ██        ░░██      ██████░░░░▒▒▒▒░░██          ██  ▒▒▒▒░░░░████          ████░░░░░░██");
        Console.WriteLine("  ██      ░░██              ████░░▒▒████████████████░░▒▒░░████                  ████░░██");
        Console.WriteLine("██    ░░░░▓▓                    ████░░░░  ░░░░    ░░████▓▓                          ████");
        Console.WriteLine("██    ████                    ██  ░░████████████████░░░░  ██                            ");
        Console.WriteLine("██████                        ██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████  ██                          ");
        Console.WriteLine("                            ██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██  ██                        ");
        Console.WriteLine("                          ██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████                      ");
        Console.WriteLine("                          ██▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██                    ");
        Console.WriteLine("                        ██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▓▓▓▓██                    ");
        Console.WriteLine("                        ██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓                  ");
        Console.WriteLine("                      ██▓▓▒▒▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓██                  ");
        Console.WriteLine("                      ██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██                  ");
        Console.WriteLine("                      ██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                      ██▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                      ██▓▓▓▓██▓▓▓▓██░░██▓▓▓▓▓▓██░░██▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                      ██▓▓▓▓██▓▓▓▓██░░██▓▓▓▓▓▓██░░██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                      ██▓▓▓▓▓▓██▓▓██░░██████████░░██████▓▓██▓▓▓▓████▓▓██                ");
        Console.WriteLine("                        ██▓▓▓▓████▓▓▓▓░░░░░░░░░░░░░░░░░░████▓▓██  ████                  ");
        Console.WriteLine("                        ██▓▓▓▓████░░░░░░          ██████░░██▓▓██░░████                  ");
        Console.WriteLine("                          ██▓▓██▒▒██████        ██▓▓▓▓░░░░██▓▓██░░████                  ");
        Console.WriteLine("                          ██▓▓██░░  ▓▓▓▓██              ██▓▓▒▒████▓▓██                  ");
        Console.WriteLine("                            ██▒▒██                      ██████▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                              ▓▓▓▓░░        ██░░        ░░░░██▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                              ██▓▓██            ▒▒      ░░██▓▓▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                              ██▓▓██        ▒▒▒▒      ░░██░░██▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                              ██▓▓▓▓██      ░░░░      ████░░██▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                            ██▓▓▓▓▓▓▓▓████        ████░░██░░██▓▓▓▓▓▓▓▓██                ");
        Console.WriteLine("                            ██▓▓████████░░████████░░░░██  ░░████▓▓▓▓▓▓██                ");
        Console.WriteLine("                          ██████░░░░░░██  ░░██░░░░████  ░░██▒▒░░████▓▓████              ");
        Console.WriteLine("                        ██░░        ░░██  ░░░░████    ░░░░██░░░░░░░░██▓▓██              ");
        Console.WriteLine("                        ██          ░░██  ████░░░░██░░░░██░░░░      ░░██▓▓██            ");
        Console.WriteLine("                      ██░░        ░░██▒▒██▒▒██░░░░████░░██░░░░      ░░██▓▓██            ");
        Console.WriteLine("                      ██          ██▒▒░░▒▒▒▒▒▒████▒▒▒▒██▒▒██░░        ░░██▓▓██          ");
        Console.WriteLine("                      ██    ░░    ██░░░░▒▒▒▒██░░░░██░░▒▒▒▒▒▒██░░      ░░██▓▓██          ");
        Console.WriteLine("                      ██  ░░██  ░░██░░▒▒▒▒██░░░░░░██░░░░▒▒▒▒██░░      ░░██▓▓▓▓██        ");
        Console.WriteLine("                      ██  ██    ░░██▒▒▒▒██░░░░░░░░██░░░░▒▒▓▓░░░░      ░░██▓▓▓▓▓▓██▓▓    ");
        Console.WriteLine("                    ██  ░░██      ░░████░░░░░░░░  ██░░░░██░░░░░░    ░░░░██▓▓▓▓▓▓▓▓▓▓██  ");
        Console.WriteLine("                    ██  ██          ░░░░░░░░░░    ░░████░░░░░░██░░  ░░░░██▓▓▓▓▓▓██████  ");
        Console.WriteLine("                    ██  ██            ░░░░░░░░      ▒▒▒▒░░░░░░██░░░░░░░░██▓▓████        ");
        Console.WriteLine("             ———————————————————————————————————————————————————————————————————————————");
        Console.WriteLine("                           ▄▄▄.  ▄▌     ▌                       ▄▄▄  ▄ .▄  ▄. ▄▌*");
        Console.WriteLine("                          ▐█ ▀█  ██.▄█  █ *.     * .    *      ▐█ █*██*▐█ ▐█*██▌.");
        Console.WriteLine("                          ▄█▀▀█  ██*█ █ ▌  ▄█▀▄   ▄█▀▄   ▄█▀▄  ██ ▄ ██▀▀█ ▐█▌▐█*");
        Console.WriteLine("                          ▐█ *▐▌ ▐█▌█ ▐█▌ ▐█▌.▐▌ ▐█▌.▐▌ ▐█▌.▐▌ ▐█ █ ██  █  ▐█▀.*");
        Console.WriteLine("                           ▀  ▀   ▀▀▀  ▀*  ▀█▄▀*  ▀█▄▀*  ▀█▄▀* .▀▀▀ ▀▀  .   ▀ * ");
        Console.WriteLine("             ———————————————————————————————————————————————————————————————————————————");
        Console.WriteLine("                                  Funny ping tool by Awooochy#3165");
        Console.WriteLine("                             READ THE INSTRUCTIONS DON'T BE A DUMMIE LOL");
        Console.WriteLine("                                      -one for only 1 IP Mode");
        Console.WriteLine("                                    -more for Multiple IPs Mode");

        string pingMode = Console.ReadLine();

        List<string> ipAddresses = new List<string>();

        if (pingMode == "-one") {
            Console.WriteLine("Gimme the IP and I'll get the work done OwO:");
            string ipAddress = Console.ReadLine();
            ipAddresses.Add(ipAddress);
        } else if (pingMode == "-more") {
            Console.WriteLine("Enter how many IPs you want to ping (between 2 and 10):");
            int numIps = int.Parse(Console.ReadLine());

            if (numIps < 2 || numIps > 10) {
                Console.WriteLine("Are you braindead? I told you between 2 and 10....");
                return;
            }

            for (int i = 1; i <= numIps; i++) {
                Console.WriteLine($"Enter IP address #{i} to ping:");
                string ipAddress = Console.ReadLine();
                ipAddresses.Add(ipAddress);
            }

        } else {
            Console.WriteLine("Invalid ping mode dummie.");
            return;
        }

        foreach (string ipAddress in ipAddresses) {
            string locationInfo = GetLocationInfo(ipAddress);
            Console.WriteLine($"IP Address: {ipAddress}\nLocation Info: {locationInfo}\n");

            Console.WriteLine("Put the ports were things go in. I don't mean that hole UwU:");
            int portNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Add some cute words:");
            string data = Console.ReadLine();

            Console.WriteLine("Gimme the ping number not that number B- baka!:");
            int pingCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Gimme the some space between pings in ms:");
            int delay = int.Parse(Console.ReadLine());

            if (delay < 1) {
                delay = 1;
            }

            byte[] buffer = Encoding.ASCII.GetBytes(data);

            Ping ping = new Ping();

            for (int i = 0; i < pingCount; i++) {
                PingReply reply = ping.Send(ipAddress, 1000, buffer);

                if (reply.Status == IPStatus.Success) {
                    Console.WriteLine($"Ping {i + 1} succeeded to {ipAddress}:{portNumber} with data: {data}");
                } else {
                    Console.WriteLine($"Ping {i + 1} failed to {ipAddress}:{portNumber} with data: {data}");
                }

                if (i < pingCount - 1) {
                    Thread.Sleep(delay);
                }
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }

    static string GetLocationInfo(string ipAddress) {
        using (var httpClient = new HttpClient()) {
            string apiAccessKey = "put here the api key"; // replace with your own API access key from ipstack.com
            string url = $"http://api.ipstack.com/{ipAddress}?access_key={apiAccessKey}";

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode) {
                dynamic locationData = JsonConvert.DeserializeObject(responseContent);
                string countryName = locationData.country_name;
                string regionName = locationData.region_name;
                string cityName = locationData.city;
                string zipCode = locationData.zip;
                string latitude = locationData.latitude;
                string longitude = locationData.longitude;
                string isp = locationData.isp;
                string domain = locationData.hostname;

                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrEmpty(countryName))
                {
                    sb.Append($"Country: {countryName}");
                }

                if (!string.IsNullOrEmpty(regionName))
                {
                    sb.Append($", Region: {regionName}");
                }

                if (!string.IsNullOrEmpty(cityName))
                {
                    sb.Append($", City: {cityName}");
                }

                if (!string.IsNullOrEmpty(zipCode))
                {
                    sb.Append($", Zip Code: {zipCode}");
                }

                if (!string.IsNullOrEmpty(latitude) && !string.IsNullOrEmpty(longitude))
                {
                    sb.Append($", Coordinates: {latitude}, {longitude}");
                }

                if (!string.IsNullOrEmpty(isp))
                {
                    sb.Append($", Provider: {isp}");
                }

                if (!string.IsNullOrEmpty(domain))
                {
                    sb.Append($", DNS: {domain}");
                }

                return sb.ToString();
            }
            else
            {
                return "We coudln't get the info :(";
            }
        }
    }
}
