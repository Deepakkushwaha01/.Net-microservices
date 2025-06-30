using Mst.Common.Packages.Results;

namespace Mst.Common.Packages.Enumerations
{
    public class OrderByEnumeration : CodeEnumeration
    {
        public static readonly OrderByEnumeration Asc = new OrderByEnumeration("ASC");

        public static readonly OrderByEnumeration Desc = new OrderByEnumeration("DESC");
        public OrderByEnumeration() { }

        public OrderByEnumeration(string type) : base(type)
        {
        }

        public static Result<OrderByEnumeration> GetByCode(string code)
        {
            OrderByEnumeration? module = GetByCode<OrderByEnumeration>(code);

            if (module is null)
            {
                return Result.Invalid<OrderByEnumeration>(ResultErrorCodesCommon.InvalidOrderBy);
            }

            return Result.Ok(module);
        }

        public static implicit operator string(OrderByEnumeration obj) => obj.Code;
    }
}