using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;

namespace RESTAPI1.Midterm.sagatajelen
{
    [ApiController]
    [Route("midtermsagatajelen")]
    public class CountryController : Controller
    {

        [HttpGet("gdp")]
        [EnableCors("MyPolicy")]

        public ActionResult<IEnumerable<CountryHolder>> Get(String country)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=ccgserver.database.windows.net;Initial Catalog=Week2;User ID=ccgadmin;Password=N9jvLf65");
            sqlConnection.Open();
            SqlCommand sqlCommand;
            if (country == "")
            {
                sqlCommand = new SqlCommand("SELECT Country, GDP FROM midtermsagata where Country", sqlConnection);
            }
            else
            {
                sqlCommand = new SqlCommand("SELECT Country, GDP FROM midtermsagatajelen where Country like '%" + country + "%'", sqlConnection);
            }
            var result = sqlCommand.ExecuteReader();
            List<CountryHolder> holder = new List<CountryHolder>();
            while (result.Read())
            {
                holder.Add(new CountryHolder { Country = result[0].ToString(), GDP = result[1] });
            }
            sqlConnection.Close();
            return holder;

        }

    }
}