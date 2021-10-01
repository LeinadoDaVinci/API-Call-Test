using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ApiCall
{
    class Program   //Objective: Make an API call from the link and list the employees in a list that looks good
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.ListMethod();
        }

        private async Task ListMethod()
        {
            List<string> Profiles = new List<string>();
            string rawresponse = await client.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
            datastuff distinguishedJson = JsonConvert.DeserializeObject<datastuff>(rawresponse);

            foreach (var item in distinguishedJson.data)
            {
                Profiles.Add("ID:" + item.id +
                 "\nNamn:" + item.employee_name +
                 "\nLön:" + item.employee_salary +
                 "\nÅlder:" + item.employee_age +
                 "\n\n");
            }

            foreach (var item1 in Profiles)
            {
                Console.WriteLine(item1);
            }

            System.Threading.Thread.Sleep(5000); //Prevents Too Many Requests error from occurring
        }
    }

    public class datastuff
    {
        public string status { get; set; }
        public Profile[] data { get; set; }
    }

    public class Profile
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image {get; set; } //Note: They do not have a profile image.
    }
}
