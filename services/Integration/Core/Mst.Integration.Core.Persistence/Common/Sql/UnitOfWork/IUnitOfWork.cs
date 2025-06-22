namespace Mst.Core.Contracts.Common.UnitOfWork
{
    using System.Threading.Tasks;
    using Mst.SharedKernel.Common.Results;

    public interface IUnitOfWork
    {
        /// <summary>
        /// saves the current context of changes
        /// </summary>
        /// <returns></returns>
        Task<Result> SaveAsync();
    }
}
