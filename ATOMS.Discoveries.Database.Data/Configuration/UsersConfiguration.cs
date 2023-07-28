using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> entity)
	{
		entity.HasKey(e => e.Id);

		var users = new User[]
		{
			new User(1, "Maverick von Fritzwilliams"),
			new User(2, "Dragon Kreig"),
			new User(3, "Nut")
		};
		entity.HasData(users);
	}
}
