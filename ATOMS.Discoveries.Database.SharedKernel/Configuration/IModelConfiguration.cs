using Microsoft.EntityFrameworkCore;

namespace Atoms.Discoveries.Database.SharedKernel.Configuration
{
    public interface IModelConfiguration
    {
        void ConfigureModel(ModelBuilder modelBuilder);
    }
}