using System;
using System.Collections.Generic;
using Newtonsoft;

namespace Spyder_Rest_Client
{
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Data;
    using Newtonsoft.Json;
    using System.IO;

    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static String responseString;

        private static TeamNicknameMap nicknameMap = new TeamNicknameMap();

        static void Main(string[] args)
        {
            ProcessRepositories().Wait();
        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "Team 5607 Event Data CSV Generator");
            client.DefaultRequestHeaders.Add("X-TBA-Auth-Key", "");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // First test: get all events data - commented out for now
            //var stringTask = client.GetStringAsync("https://www.thebluealliance.com/api/v3/events/2019");

            // Event keys:
            //   Holly Springs - 2019ncwak
            //   Guilford Co   - 2019ncgui
            //   Asheville     - 2019ncash
            //   Pembroke      - 2019ncpem
            //   District      - 2019nccmp

            // Individual Event data - commented out for now
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncwak");
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncgui");
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncash");
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncpem");
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019nccmp");


            // Rankings data
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncwak/rankings");
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncgui/rankings");
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncash/rankings");
            var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncpem/rankings");
            //var response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019nccmp/rankings");
            
            // UTF8 encode the response
            responseString = Encoding.UTF8.GetString(response, 0, response.Length);

            RankingsData rankingsData = jsonStringToTable(responseString);

            // OPRS data
            //response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncwak/oprs");
            //response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncgui/oprs");
            //response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncash/oprs");
            response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019ncpem/oprs");
            //response = await client.GetByteArrayAsync("https://www.thebluealliance.com/api/v3/event/2019nccmp/oprs");
            
            // UTF8 encode the response
            responseString = Encoding.UTF8.GetString(response, 0, response.Length);

            var deser = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, float>>>(responseString);
            var oprs = deser["oprs"];
            var dprs = deser["dprs"];
            var ccwms = deser["ccwms"];
            //Console.Write(ccwms["frc5607"]);
            //Console.Write(dprs["frc5607"]);
            //Console.Write(oprs["frc5607"]);
            
            // Console debug, comment/uncomment as needed
            /* Console.Write("Team, " 
                + rankingsData.sort_order_info[0].name + ", " 
                + rankingsData.sort_order_info[1].name + ", " 
                + rankingsData.sort_order_info[2].name + ", " 
                + rankingsData.sort_order_info[3].name + ", " 
                + rankingsData.sort_order_info[4].name + Environment.NewLine);

            foreach (Ranking element in rankingsData.rankings) 
            {
                Console.Write(element.team_key + ", "
                    + element.sort_orders[0] + ", "
                    + element.sort_orders[1] + ", "
                    + element.sort_orders[2] + ", "
                    + element.sort_orders[3] + ", "
                    + element.sort_orders[4] + Environment.NewLine);
            }*/

            // Create the Public folder to dump the CSV
            Directory.CreateDirectory("c:\\Users\\Public\\FRCEvents");

            // Generate the CSV header
            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(@"C:\Users\Public\FRCEvents\Event.csv"))
            {
                file.Write("Team, "
                    + "Nickname, " 
                    + rankingsData.sort_order_info[0].name + ", " 
                    + rankingsData.sort_order_info[1].name + ", " 
                    + rankingsData.sort_order_info[2].name + ", " 
                    + rankingsData.sort_order_info[3].name + ", " 
                    + rankingsData.sort_order_info[4].name + ", " 
                    + "oprs, "
                    + "dprs, "
                    + "ccwms" 
                    + Environment.NewLine);
            }

            // Generate the CSV row data
            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(@"C:\Users\Public\FRCEvents\Event.csv", true))
            {
                foreach (Ranking element in rankingsData.rankings) 
                {
                    file.Write(element.team_key + ", "
                        + nicknameMap.getTeamNickname(element.team_key) + ", "
                        + element.sort_orders[0] + ", "
                        + element.sort_orders[1] + ", "
                        + element.sort_orders[2] + ", "
                        + element.sort_orders[3] + ", "
                        + element.sort_orders[4] + ", " 
                        + oprs[element.team_key] + ", "
                        + dprs[element.team_key] + ", "
                        + ccwms[element.team_key] + ", "
                        + Environment.NewLine);
                }
            }
        }

        private static RankingsData jsonStringToTable(string jsonContent)
        {
            RankingsData dt = JsonConvert.DeserializeObject<RankingsData>(jsonContent);
            return dt;
        }
    }
}