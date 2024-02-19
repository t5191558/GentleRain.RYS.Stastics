using MyRequest = GentleRain.RYS.Statistic.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<GentleRain.RYS.Statistic.Administration.UserRow>;
using MyRow = GentleRain.RYS.Statistic.Administration.UserRow;

namespace GentleRain.RYS.Statistic.Administration;
public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
{
    public UserListHandler(IRequestContext context)
         : base(context)
    {
    }
}