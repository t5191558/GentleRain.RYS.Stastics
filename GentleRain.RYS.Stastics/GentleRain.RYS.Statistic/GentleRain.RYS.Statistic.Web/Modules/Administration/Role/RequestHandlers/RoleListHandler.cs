using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<GentleRain.RYS.Statistic.Administration.RoleRow>;
using MyRow = GentleRain.RYS.Statistic.Administration.RoleRow;


namespace GentleRain.RYS.Statistic.Administration;
public interface IRoleListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class RoleListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IRoleListHandler
{
    public RoleListHandler(IRequestContext context)
         : base(context)
    {
    }
}