namespace Refacto.DotNet.Controllers.Applications.StrategyProduct
{
    public interface IStrategyProduct
    {
        bool CanProcess(Entities.Product product);
        void Execute(Entities.Product product);
    }
}