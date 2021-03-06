using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class IP_Repostirory
    {
        public List<string> SearchList = new List<string>();
        public static string CallApi(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create("https://ipwhois.app/json/" + url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            result = "[" + result + "]";
            result = result.Replace("'", "''");
            return result;
        }

        public void ImportIP(string url)
        {
            string sjson = CallApi(url);

            JArray json = JArray.Parse(sjson);
            foreach (JObject item in json)
            {
                string ip = (string)item.GetValue("ip");
                bool success = (bool)item.GetValue("success");
                string type = (string)item.GetValue("type");
                string continent = (string)item.GetValue("continent");
                string continent_code = (string)item.GetValue("continent_code");
                string country = (string)item.GetValue("country");
                string country_code = (string)item.GetValue("country_code");
                string country_flag = "https://flagcdn.com/h80/" + country_code.ToLower() + ".png";
                string country_capital = (string)item.GetValue("country_capital");
                string country_phone = (string)item.GetValue("country_phone");
                string country_neighbours = (string)item.GetValue("country_neighbours");
                string region = (string)item.GetValue("region");
                string city = (string)item.GetValue("city");
                string latitude = (string)item.GetValue("latitude");
                string longitude = (string)item.GetValue("longitude");
                string asn = (string)item.GetValue("asn");
                string org = (string)item.GetValue("org");
                string isp = (string)item.GetValue("isp");
                string timezone = (string)item.GetValue("timezone");
                string timezone_name = (string)item.GetValue("timezone_name");
                string timezone_dstOffset = (string)item.GetValue("timezone_dstOffset");
                string timezone_gmtOffset = (string)item.GetValue("timezone_gmtOffset");
                string timezone_gmt = (string)item.GetValue("timezone_gmt");
                string currency = (string)item.GetValue("currency");
                string currency_code = (string)item.GetValue("currency_code");
                string currency_symbol = (string)item.GetValue("currency_symbol");
                string currency_rates = (string)item.GetValue("currency_rates");
                string currency_plural = (string)item.GetValue("currency_plural");
                int completed_requests = (int)item.GetValue("completed_requests");

                if (latitude == null)
                {
                    latitude = "0.0";
                }
                if (longitude == null)
                {
                    longitude = "0.0";
                }
                if (currency_rates == null)
                {
                    currency_rates = "0.0";
                }

                string sSqlConnectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=Vsmti1234!;";
                using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
                using (DbCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandText = "INSERT INTO Majcenic_IpAdrese " +
                        "(ip, success, type, continent, continent_code, country, country_code, country_flag, country_capital, country_phone, " +
                        "country_neighbours, region, city, latitude, longitude, asn, org, isp, timezone, timezone_name, timezone_dstOffset," +
                        "timezone_gmtOffset, timezone_gmt, currency, currency_code, currency_symbol, currency_rates, currency_plural, completed_requests) " +
                        "VALUES('" + ip.ToLower() + "', '" + success + "', '" + type + "', '" + continent + "', '" + continent_code + "', '" + country + "', '" + 
                        country_code + "', '" + country_flag + "', '" + country_capital + "', '" + country_phone + "', '" + country_neighbours + "', '" +
                        region + "', '" + city + "', '" + latitude + "', '" + longitude + "', '" + asn + "', '" + org + "', '" + isp + "', '" +
                        timezone + "', '" + timezone_name + "', '" + timezone_dstOffset + "', '" + timezone_gmtOffset + "', '" + timezone_gmt + "', '" +
                        currency + "', '" + currency_code + "', '" + currency_symbol + "', '" + currency_rates + "', '" + currency_plural + "', '" +
                        completed_requests + "')";

                    oConnection.Open();
                    oCommand.CommandText = oCommand.CommandText.Replace("''", "'NO DATA'");
                    using (DbDataReader oReader = oCommand.ExecuteReader())
                    {

                    }
                }
            }
        }

        public void DeleteIP(string IPdelete)
        {
            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=Vsmti1234!;";
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Majcenic_IpAdrese WHERE ip ='" + IPdelete.ToLower() + "'";
                connection.Open();
                using (DbDataReader oReader = command.ExecuteReader())
                {

                }
            }
        }

        public void UpdateIP(IP ipObject)
        {
            string sSqlConnectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=Vsmti1234!;";
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))
            using (DbCommand oCommand = oConnection.CreateCommand())
            {
                
                oCommand.CommandText = $"UPDATE Majcenic_IpAdrese SET continent = '{ipObject.continent}', continent_code = '{ipObject.continent_code}'," 
                    + $"country = '{ipObject.country}', country_code = '{ipObject.country_code}', country_capital = '{ipObject.country_capital}',"
                    + $"country_phone = '{ipObject.country_phone}', country_neighbours = '{ipObject.country_neighbours}', region = '{ipObject.region}',"
                    + $"city = '{ipObject.city}', latitude = '{Convert.ToString(ipObject.latitude).Replace(',', '.')}', longitude = '{Convert.ToString(ipObject.longitude).Replace(',', '.')}',"
                    + $"asn = '{ipObject.asn}', org = '{ipObject.org}', isp = '{ipObject.isp}', timezone = '{ipObject.timezone}', timezone_name = '{ipObject.timezone_name}',"
                    + $"timezone_dstOffset = '{ipObject.timezone_dstOffset}', timezone_gmtOffset = '{ipObject.timezone_gmtOffset}', timezone_gmt = '{ipObject.timezone_gmt}',"
                    + $"currency = '{ipObject.currency}', currency_code = '{ipObject.currency_code}', currency_symbol = '{ipObject.currency_symbol}',"
                    + $"currency_rates = '{Convert.ToString(ipObject.currency_rates).Replace(',', '.')}', currency_plural = '{ipObject.currency_plural}'"
                    + $"WHERE ip = '{ipObject.ip}'";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {

                }
            }
        }

        public List<IPMainForm> GetIPMainForm()
        {
            List<IPMainForm> ListIP = new List<IPMainForm>();

            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=Vsmti1234!;";
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ip, type, country, city, isp FROM Majcenic_IpAdrese";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListIP.Add(new IPMainForm()
                        {
                             ip = (string)reader["ip"],
                             type = (string)reader["type"],
                             country = (string)reader["country"],                           
                             city = (string)reader["city"],
                             isp = (string)reader["isp"],
                    });
                    }
                }
            }

            return ListIP;
        }

        public IP GetIPDetails(string IPdetails)
        {
            IP OneIP = new IP();

            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=Vsmti1234!;";
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Majcenic_IpAdrese WHERE ip='" + IPdetails + "'";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OneIP.ip = (string)reader["ip"];
                        OneIP.success = (bool)reader["success"];
                        OneIP.type = (string)reader["type"];
                        OneIP.continent = (string)reader["continent"];
                        OneIP.continent_code = (string)reader["continent_code"];
                        OneIP.country = (string)reader["country"];
                        OneIP.country_code = (string)reader["country_code"];
                        OneIP.country_flag = (string)reader["country_flag"]; ;
                        OneIP.country_capital = (string)reader["country_capital"];
                        OneIP.country_phone = (string)reader["country_phone"];
                        OneIP.country_neighbours = (string)reader["country_neighbours"];
                        OneIP.region = (string)reader["region"];
                        OneIP.city = (string)reader["city"];
                        OneIP.latitude = Convert.ToDecimal(reader["latitude"]);
                        OneIP.longitude = Convert.ToDecimal(reader["longitude"]);
                        OneIP.asn = (string)reader["asn"];
                        OneIP.org = (string)reader["org"];
                        OneIP.isp = (string)reader["isp"];
                        OneIP.timezone = (string)reader["timezone"];
                        OneIP.timezone_name = (string)reader["timezone_name"];
                        OneIP.timezone_dstOffset = (string)reader["timezone_dstOffset"];
                        OneIP.timezone_gmtOffset = (string)reader["timezone_gmtOffset"];
                        OneIP.timezone_gmt = (string)reader["timezone_gmt"];
                        OneIP.currency = (string)reader["currency"];
                        OneIP.currency_code = (string)reader["currency_code"];
                        OneIP.currency_symbol = (string)reader["currency_symbol"];
                        OneIP.currency_rates = Convert.ToDecimal(reader["currency_rates"]);
                        OneIP.currency_plural = (string)reader["currency_plural"];
                        OneIP.completed_requests = (int)reader["completed_requests"];
                    }
                }
            }

            /*foreach (PropertyInfo prop in OneIP.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (type == typeof(string) && prop.GetValue(OneIP).ToString() == "")
                {
                    
                }
            }*/

            return OneIP;
        }

        public bool IsValidIP(string IPimport)
        {
            bool valid = true;
            IPimport = IPimport.ToLower();

            char[] allowed = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', '.', ':'};

            if(IPimport.Any(x => !allowed.Contains(x)))
            {
                valid = false;
            }

            if (valid == true)
            {
                string sjson = CallApi(IPimport);

                if (sjson == "[]" || sjson == "[[]]")
                {
                    valid = false;
                }
                else
                {
                    JArray json = JArray.Parse(sjson);
                    foreach (JObject item in json)
                    {
                        valid = (bool)item.GetValue("success");
                    }
                }
            }

            return valid;
        }

        public bool IsUniqueIP(string IPimport)
        {
            List<string> ListIP = new List<string>();

            string connectionString = "Server=193.198.57.183;Database=STUDENTI_PIN;User Id=pin;Password=Vsmti1234!;";
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ip FROM Majcenic_IpAdrese";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListIP.Add((string)reader["ip"]);
                    }
                }
            }

            bool IPunique = true;
            foreach(var v in ListIP)
            {
                if(v == IPimport.ToLower())
                {
                    IPunique = false;
                    break;
                }
            }

            return IPunique;
        }

        public List<IPMainForm> SearchAndSort(bool WriteToLog, string TxtBox, bool IPv4, bool IPv6, List<string> MissingCountriesList, string Attribute, bool Asc)
        {
            //Adding time to logs
            string SearchString = DateTime.Now.ToString();

            //Adding search term to logs
            if(TxtBox == "")
            {
                SearchString += " - Search term: None";
            }
            else
            {
                SearchString += " - Search term: '" + TxtBox + "'";
            }
            
            TxtBox = TxtBox.ToLower();

            List<IPMainForm> FilterIPs = GetIPMainForm();
            FilterIPs = FilterIPs.Where(x => !MissingCountriesList.Contains(x.country)).ToList();

            FilterIPs = FilterIPs.Where(x => x.ip.ToLower().Contains(TxtBox)
            || x.country.ToLower().Contains(TxtBox) 
            || x.city.ToLower().Contains(TxtBox) 
            || x.isp.ToLower().Contains(TxtBox)).ToList();

            //Adding IP version to logs
            if(IPv4 == false)
            {
                FilterIPs = FilterIPs.Where(x => x.type != "IPv4").ToList();
                SearchString += ", IPv4 not included";
            }
            else
            {
                SearchString += ", IPv4 included";
            }

            if(IPv6 == false)
            {
                FilterIPs = FilterIPs.Where(x => x.type != "IPv6").ToList();
                SearchString += ", IPv6 not included";
            }
            else
            {
                SearchString += ", IPv6 included";
            }

            //Adding countries to logs
            List<string> CountriesList = FilterIPs.Select(x => x.country).Distinct().OrderBy(x => x).ToList();
            SearchString += ", Countries included: ";
            if (CountriesList.Count == 0)
            {
                SearchString += "None";
            }
            else
            {
                foreach (string country in CountriesList)
                {
                    SearchString += country + ", ";
                }
                SearchString = SearchString.Substring(0, SearchString.Length - 2);
            }
            


            if (Asc == true)
            {
                switch(Attribute)
                {
                    case "IP":
                        FilterIPs = FilterIPs.OrderBy(x => x.ip).ToList();
                        break;
                    case "Country":
                        FilterIPs = FilterIPs.OrderBy(x => x.country == "NO DATA").ThenBy(x => x.country).ToList();
                        break;
                    case "City":
                        FilterIPs = FilterIPs.OrderBy(x => x.city == "NO DATA").ThenBy(x => x.city).ToList();
                        break;
                    case "Internet Service Provider":
                        FilterIPs = FilterIPs.OrderBy(x => x.isp == "NO DATA").ThenBy(x => x.isp).ToList();
                        break;
                }
            }
            else
            {
                switch (Attribute)
                {
                    case "IP":
                        FilterIPs = FilterIPs.OrderByDescending(x => x.ip).ToList();
                        break;
                    case "Country":
                        FilterIPs = FilterIPs.OrderBy(x => x.country == "NO DATA").ThenByDescending(x => x.country).ToList();
                        break;
                    case "City":
                        FilterIPs = FilterIPs.OrderBy(x => x.city == "NO DATA").ThenByDescending(x => x.city).ToList();
                        break;
                    case "Internet Service Provider":
                        FilterIPs = FilterIPs.OrderBy(x => x.isp == "NO DATA").ThenByDescending(x => x.isp).ToList();
                        break;
                }
            }

            //Adding results to logs
            SearchString += "\n==========================================================";
            if(FilterIPs.Count() == 0)
            {
                SearchString = SearchString + "\nNo data matched the criteria";
            }
            else
            {
                foreach (var v in FilterIPs)
                {
                    SearchString = SearchString + $"\n{v.ip}-{v.type}-{v.country}-{v.city}-{v.isp}";
                }
            }
            SearchString += "\n==========================================================\n";

            if (WriteToLog == true)
            {
                SearchList.Add(SearchString);
            }
            return FilterIPs;
        }

        public void WriteToTxt()
        {
            if(SearchList.Count != 0)
            {
                File.AppendAllLines("..\\..\\..\\logs.txt", SearchList);
                SearchList.Clear();
            }
        }
    }
}
