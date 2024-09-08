using AutoMapper;
using Mahas.Components;
using Microsoft.Extensions.Options;

namespace pacsapi.Repository
{
    public class RepositoryWrapper
    {
        private enum SqlConnection
        {
            MainConnection,
        };

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        private string GetConnectionString(SqlConnection connection) => _config.GetConnectionString(connection.ToString());

        public RepositoryWrapper(IConfiguration config, IMapper mapper, IOptions<AppSettings> options)
        {
            _config = config;
            _mapper = mapper;
            _appSettings = options.Value;
        }

        private OrderRepository order;
        public OrderRepository Order
        {
            get
            {
                order ??= new OrderRepository(GetConnectionString(SqlConnection.MainConnection), _mapper, _config);

                return order;
            }
        }

        private ResultRepository result;
        public ResultRepository Result
        {
            get
            {
                result ??= new ResultRepository(GetConnectionString(SqlConnection.MainConnection), _mapper, _config);

                return result;
            }
        }
    }
}
