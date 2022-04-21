using DataAccess.Abstract;
using Microsoft.AspNetCore.SignalR;
using TableDependency.SqlClient;
using WebAPI.Hubs;

namespace WebAPI.Subscription
{
    public class DatabaseSubscription<T> : IDatabaseSubscription where T : class,new ()
    {
        IConfiguration _configuration;
        IHubContext<VoteHub> _hubContext;
        IUserTestDal _userTestDal;

        public DatabaseSubscription(IConfiguration configuration,IHubContext<VoteHub> hubContext,IUserTestDal userTestDal)
        {
            _configuration = configuration;
            _hubContext = hubContext;
            _userTestDal = userTestDal;
        }

        SqlTableDependency<T> _tableDependency;
        public void Configure(string tableName)
        {
            _tableDependency = new SqlTableDependency<T>(_configuration.GetConnectionString("UserConnection"), tableName);
            _tableDependency.OnChanged +=async (o,e) => 
            {
                
                if (_hubContext.Clients.Client==_hubContext.Clients.User)
                {
                    await _hubContext.Clients.All.SendAsync("receiveMessage", "Data Değişti");
                }
                
            };
            _tableDependency.OnError+=(o,e) => { 
            
            
            };

            _tableDependency.Start();
        }

        ~DatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }
}
