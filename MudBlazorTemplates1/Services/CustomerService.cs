using Dapper;
using MudBlazor.Charts;
using MudBlazorTemplates1.Data;
using Npgsql;

namespace MudBlazorTemplates1.Services
{

    public interface ICustomerService
    {
        List<customer> getAllData();
    }
    public class CustomerService : ICustomerService
    {
        public List<customer> getAllData()
        {
            List<customer> RestData = new List<customer>();
            using (NpgsqlConnection cnn = new NpgsqlConnection(Gbvar.gbConnStr))
            {
                cnn.Open();
                var sql = "select * from customer  order by code";
                RestData = cnn.Query<customer>(sql).ToList();
            }

            return RestData;
        }
    }
}
